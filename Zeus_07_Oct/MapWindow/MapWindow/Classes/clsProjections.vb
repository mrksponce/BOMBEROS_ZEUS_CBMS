Option Strict Off

Public Class clsProjections
    Public Class clsProjection
        Public MainCateg As String
        Public Category As String
        Public Name As String
        Public PROJ4 As String

        Public Sub New(ByVal iMainCateg As String, ByVal iCategory As String, ByVal iName As String, ByVal iPROJ4 As String, ByVal iESRIWKT As String, ByVal iSTDWKT As String)
            MainCateg = iMainCateg
            Category = iCategory
            Name = iName
            PROJ4 = iPROJ4
        End Sub

        Public Sub New()
        End Sub
    End Class

    Public ProjectionList As New ArrayList

    'Do this to get a static member, basically
    Public Function GetOrSetLastCustomProj4(ByRef inout As String, ByVal setting As Boolean) As String
        Static lastCustomProjectionPROJ4 As String

        If Not setting Then
            If Not inout = "" Then inout = lastCustomProjectionPROJ4
            Return lastCustomProjectionPROJ4
        Else
            lastCustomProjectionPROJ4 = inout
            Return lastCustomProjectionPROJ4
        End If
    End Function

    Public Function FindProjectionByPROJ4(ByVal proj4 As String, Optional ByVal Tolerant As Boolean = True) As clsProjection
        If proj4 = "" Then Return Nothing
        proj4 = proj4.ToLower().Trim()

        For i As Integer = 0 To ProjectionList.Count - 1
            Dim comparing As String = ProjectionList.Item(i).PROJ4.ToLower().Trim()
            If PartsCompare(proj4, comparing, Tolerant) Then
                Return ProjectionList.Item(i)
            End If
        Next

        'If we got here, an existing proj4 string wasn't recognized; call it "Custom" and
        'let it have the given proj4 string.
        Dim newPrj As New clsProjection
        newPrj.Category = "Custom Projection"
        newPrj.MainCateg = "Custom Projection"
        newPrj.Name = "Custom Projection"
        newPrj.PROJ4 = proj4
        GetOrSetLastCustomProj4(proj4, True)

        Return newPrj
    End Function

    Public Shared Function PartsCompare(ByVal instr1 As String, ByVal instr2 As String, ByVal tolerant As Boolean) As Boolean
        Try
            Dim parts1() As String = instr1.Split(" ")
            Dim parts2() As String = instr2.Split(" ")

            Dim p1 As New ArrayList
            Dim p2 As New ArrayList

            For Each s As String In parts1
                s = s.Trim()
                If Not p1.Contains(s) Then p1.Add(s)
            Next

            For Each s As String In parts2
                s = s.Trim()
                If Not p2.Contains(s) Then p2.Add(s)
            Next

            If tolerant Then
                Dim p1ContainsDatum As Boolean = False
                Dim p1ContainsUnit As Boolean = False
                For i As Integer = 0 To p1.Count - 1
                    If i > p1.Count - 1 Then Exit For
                    'Doesn't seem to eval p1.count every loop

                    If p1(i).ToString().StartsWith("+no_defs") Then
                        p1.RemoveAt(i)
                        i = 0 'Restart
                    End If
                    If p1(i).ToString().StartsWith("+datum") Then p1ContainsDatum = True
                    If p1(i).ToString().StartsWith("+unit") Then p1ContainsUnit = True
                Next
                For i As Integer = 0 To p2.Count - 1
                    If i > p2.Count - 1 Then Exit For
                    'Doesn't seem to eval p2.count every loop

                    If p2(i).ToString().StartsWith("+no_defs") Then
                        p2.RemoveAt(i)
                        i = 0 'Restart
                    End If
                    If Not p1ContainsDatum AndAlso p2(i).ToString().StartsWith("+datum") Then
                        p2.RemoveAt(i)
                        i = 0 'Restart
                    End If
                    If Not p1ContainsUnit AndAlso p2(i).ToString().StartsWith("+unit") Then
                        p2.RemoveAt(i)
                        i = 0 'Restart
                    End If
                Next
            End If

            If Not p1.Count = p2.Count Then Return False

            While (p1.Count > 0)
                If p2.Contains(p1.Item(0)) Then p2.Remove(p1.Item(0))
                p1.RemoveAt(0)
            End While

            If p2.Count = 0 Then Return True
        Catch ex As Exception
            MapWinUtility.Logger.Msg(ex.ToString())
            Return False
        End Try
    End Function

    Public Function FindProjectionByCatAndName(ByVal MainCateg As String, ByVal Category As String, ByVal Name As String) As String
        For i As Integer = 0 To ProjectionList.Count - 1
            If (ProjectionList.Item(i).MainCateg.ToLower() = MainCateg.ToLower() And ProjectionList.Item(i).Category.ToLower() = Category.ToLower() And ProjectionList.Item(i).Name.ToLower() = Name.ToLower()) Then
                Return ProjectionList.Item(i).PROJ4.Trim()
            End If
        Next

        'If we got here, check for a custom projection
        If MainCateg = "Custom Projection" And Category = "Custom Projection" And Name = "Custom Projection" Then
            'Yes, it's a custom projection... Return the last-identified custom projection
            'as the custom projection.
            Dim newPrj As New clsProjection
            newPrj.Category = "Custom Projection"
            newPrj.MainCateg = "Custom Projection"
            newPrj.Name = "Custom Projection"
            newPrj.PROJ4 = GetOrSetLastCustomProj4("", False)

            Return newPrj.PROJ4
        End If

        Return ""
    End Function

    Public Sub LoadMainCategComboBox(ByRef cboCategories As Windows.Forms.ComboBox)
        cboCategories.Items.Clear()

        For i As Integer = 0 To ProjectionList.Count - 1
            If Not cboCategories.Items.Contains(ProjectionList.Item(i).MainCateg) Then
                cboCategories.Items.Add(ProjectionList.Item(i).MainCateg)
            End If
        Next

        cboCategories.Sorted = True

        cboCategories.Items.Add("Custom Projection")

        If Not cboCategories.Items.Count = 0 Then
            cboCategories.SelectedIndex = 0
        End If
    End Sub

    Public Sub LoadCategComboBox(ByVal LoadingforMainCateg As String, ByRef cboCateg As Windows.Forms.ComboBox)
        cboCateg.Items.Clear()

        For i As Integer = 0 To ProjectionList.Count - 1
            If ProjectionList.Item(i).MainCateg.ToLower() = LoadingforMainCateg.ToLower() Then
                If Not cboCateg.Items.Contains(ProjectionList.Item(i).Category) Then
                    cboCateg.Items.Add(ProjectionList.Item(i).Category)
                End If
            End If
        Next

        cboCateg.Sorted = True

        If LoadingforMainCateg = "Custom Projection" Then
            cboCateg.Items.Add("Custom Projection")
        End If

        If Not cboCateg.Items.Count = 0 Then
            cboCateg.SelectedIndex = 0
        End If
    End Sub

    Public Sub LoadNamesComboBox(ByVal LoadingforMainCateg As String, ByVal LoadingForCategory As String, ByRef cboNames As Windows.Forms.ComboBox)
        cboNames.Items.Clear()

        For i As Integer = 0 To ProjectionList.Count - 1
            If ProjectionList.Item(i).MainCateg.ToLower() = LoadingforMainCateg.ToLower() And ProjectionList.Item(i).Category.ToLower() = LoadingForCategory.ToLower() Then
                If Not cboNames.Items.Contains(ProjectionList.Item(i).Name) Then
                    cboNames.Items.Add(ProjectionList.Item(i).Name)
                End If
            End If
        Next

        cboNames.Sorted = True

        If LoadingforMainCateg = "Custom Projection" Then
            cboNames.Items.Add("Custom Projection")
        End If

        If Not cboNames.Items.Count = 0 Then
            cboNames.SelectedIndex = 0
        End If
    End Sub

    Public Sub New()
        Dim p As New clsProjection

        'Load up the projections
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "State Plane - Nad 1983"
        p.Name = "Michigan GeoRef (2008)"
        p.PROJ4 = "+proj=omerc +lat_0=45.30916666666666 +lonc=-86 +alpha=337.25556 +k=0.9996 +x_0=2546731.496 +y_0=-4354009.816 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Lambert 2 (Central France)"
        p.PROJ4 = "+proj=lcc +lat_1=45.89893890000052 +lat_2=47.69601440000037 +lat_0=46.8 +lon_0=2.33722917 +x_0=600000 +y_0=200000 +ellps=clrk80 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Lambert 2-Wide (�tendu)"
        p.PROJ4 = "+proj=lcc +lat_1=45.89891889999931 +lat_2=47.69601440000037 +lat_0=46.8 +lon_0=2.33722917 +x_0=600000 +y_0=2200000 +ellps=clrk80 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Lambert 2-Wide (�tendu)"
        p.PROJ4 = "+proj=lcc +lat_1=45.89891889999931 +lat_2=47.69601440000037 +lat_0=46.8 +lon_0=2.33722917 +x_0=600000 +y_0=2200000 +a=6378249.145 +b=6356514.96582849 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Fischer modified"
        p.PROJ4 = "+proj=longlat +ellps=fschr60m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "GRS 1967"
        p.PROJ4 = "+proj=longlat +ellps=GRS67 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "GRS 1980"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Helmert 1906"
        p.PROJ4 = "+proj=longlat +ellps=helmert +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Hough 1960"
        p.PROJ4 = "+proj=longlat +a=6378270 +b=6356794.343434343 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Indonesian National"
        p.PROJ4 = "+proj=longlat +a=6378160 +b=6356774.50408554 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "International 1924"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "International 1967"
        p.PROJ4 = "+proj=longlat +ellps=aust_SA +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Krasovsky 1940"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "OSU 1986 geoidal model"
        p.PROJ4 = "+proj=longlat +a=6378136.2 +b=6356751.516671965 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "OSU 1991 geoidal model"
        p.PROJ4 = "+proj=longlat +a=6378136.3 +b=6356751.616336684 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Plessis 1817"
        p.PROJ4 = "+proj=longlat +a=6376523 +b=6355862.933255573 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Sphere EMEP"
        p.PROJ4 = "+proj=longlat +a=6370000 +b=6370000 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Struve 1860"
        p.PROJ4 = "+proj=longlat +a=6378297 +b=6356655.847080379 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Transit precise ephemeris"
        p.PROJ4 = "+proj=longlat +ellps=WGS66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "Walbeck"
        p.PROJ4 = "+proj=longlat +a=6376896 +b=6355834.846687364 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "War Office"
        p.PROJ4 = "+proj=longlat +a=6378300.583 +b=6356752.270219594 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "WGS 1966"
        p.PROJ4 = "+proj=longlat +ellps=WGS66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1988"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1989"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1990"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1991"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1992"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1993"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1994"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1996"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 1997"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "ITRF 2000"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "NSWC 9Z-2"
        p.PROJ4 = "+proj=longlat +ellps=WGS66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "WGS 1966"
        p.PROJ4 = "+proj=longlat +ellps=WGS66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "WGS 1972 TBE"
        p.PROJ4 = "+proj=longlat +ellps=WGS72 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "WGS 1972"
        p.PROJ4 = "+proj=longlat +ellps=WGS72 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "WGS 1984"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +datum=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "World"
        p.Name = "GRS 1980"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +datum=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Anoka"
p.PROJ4 = "+proj=longlat +a=6378418.941 +b=6357033.309845551 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Becker"
p.PROJ4 = "+proj=longlat +a=6378586.581 +b=6357200.387780368 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Beltrami North"
p.PROJ4 = "+proj=longlat +a=6378505.809 +b=6357119.886593593 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Beltrami South"
p.PROJ4 = "+proj=longlat +a=6378544.823 +b=6357158.769787037 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Benton"
p.PROJ4 = "+proj=longlat +a=6378490.569 +b=6357104.697690427 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Big Stone"
p.PROJ4 = "+proj=longlat +a=6378470.757 +b=6357084.952116313 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Blue Earth"
p.PROJ4 = "+proj=longlat +a=6378403.701 +b=6357018.120942386 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Brown"
p.PROJ4 = "+proj=longlat +a=6378434.181 +b=6357048.498748716 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Carlton"
p.PROJ4 = "+proj=longlat +a=6378454.907 +b=6357069.155258362 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Carver"
p.PROJ4 = "+proj=longlat +a=6378400.653 +b=6357015.083161753 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Cass North"
p.PROJ4 = "+proj=longlat +a=6378567.378 +b=6357181.249164391 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Cass South"
p.PROJ4 = "+proj=longlat +a=6378546.957 +b=6357160.89663214 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Chippewa"
p.PROJ4 = "+proj=longlat +a=6378476.853 +b=6357091.027677579 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Chisago"
p.PROJ4 = "+proj=longlat +a=6378411.321000001 +b=6357025.715393969 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Cook North"
p.PROJ4 = "+proj=longlat +a=6378647.541 +b=6357261.14339303 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Cook South"
p.PROJ4 = "+proj=longlat +a=6378647.541 +b=6357261.14339303 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Cottonwood"
p.PROJ4 = "+proj=longlat +a=6378514.953 +b=6357128.999935492 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Crow Wing"
p.PROJ4 = "+proj=longlat +a=6378546.957 +b=6357160.89663214 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Dakota"
p.PROJ4 = "+proj=longlat +a=6378421.989 +b=6357036.347626184 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Dodge"
p.PROJ4 = "+proj=longlat +a=6378481.425 +b=6357095.584348529 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Douglas"
p.PROJ4 = "+proj=longlat +a=6378518.001 +b=6357132.037716125 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Faribault"
p.PROJ4 = "+proj=longlat +a=6378521.049 +b=6357135.075496757 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Fillmore"
p.PROJ4 = "+proj=longlat +a=6378464.661 +b=6357078.876555047 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Freeborn"
p.PROJ4 = "+proj=longlat +a=6378521.049 +b=6357135.075496757 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Goodhue"
p.PROJ4 = "+proj=longlat +a=6378434.181 +b=6357048.498748716 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Grant"
p.PROJ4 = "+proj=longlat +a=6378518.001 +b=6357132.037716125 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Hennepin"
p.PROJ4 = "+proj=longlat +a=6378418.941 +b=6357033.309845551 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Houston"
p.PROJ4 = "+proj=longlat +a=6378436.619 +b=6357050.928574564 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Isanti"
p.PROJ4 = "+proj=longlat +a=6378411.321000001 +b=6357025.715393969 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Itasca North"
p.PROJ4 = "+proj=longlat +a=6378574.389 +b=6357188.236657837 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Itasca South"
p.PROJ4 = "+proj=longlat +a=6378574.389 +b=6357188.236657837 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Jackson"
p.PROJ4 = "+proj=longlat +a=6378521.049 +b=6357135.075496757 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Kanabec"
p.PROJ4 = "+proj=longlat +a=6378472.281 +b=6357086.47100663 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Kandiyohi"
p.PROJ4 = "+proj=longlat +a=6378498.189 +b=6357112.29214201 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Kittson"
p.PROJ4 = "+proj=longlat +a=6378449.421 +b=6357063.687651882 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Koochiching"
p.PROJ4 = "+proj=longlat +a=6378525.621 +b=6357139.632167708 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Lac Qui Parle"
p.PROJ4 = "+proj=longlat +a=6378476.853 +b=6357091.027677579 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Lake of the Woods North"
p.PROJ4 = "+proj=longlat +a=6378466.185 +b=6357080.395445363 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Lake of the Woods South"
p.PROJ4 = "+proj=longlat +a=6378496.665 +b=6357110.773251694 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Le Sueur"
p.PROJ4 = "+proj=longlat +a=6378434.181 +b=6357048.498748716 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Lincoln"
p.PROJ4 = "+proj=longlat +a=6378643.579 +b=6357257.194676865 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Lyon"
p.PROJ4 = "+proj=longlat +a=6378559.758 +b=6357173.65471281 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Mahnomen"
p.PROJ4 = "+proj=longlat +a=6378586.581 +b=6357200.387780368 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Marshall"
p.PROJ4 = "+proj=longlat +a=6378441.801 +b=6357056.093200299 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Martin"
p.PROJ4 = "+proj=longlat +a=6378521.049 +b=6357135.075496757 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN McLeod"
p.PROJ4 = "+proj=longlat +a=6378414.369 +b=6357028.753174601 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Meeker"
p.PROJ4 = "+proj=longlat +a=6378498.189 +b=6357112.29214201 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Morrison"
p.PROJ4 = "+proj=longlat +a=6378502.761 +b=6357116.84881296 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Mower"
p.PROJ4 = "+proj=longlat +a=6378521.049 +b=6357135.075496757 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Murray"
p.PROJ4 = "+proj=longlat +a=6378617.061 +b=6357230.765586698 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Nicollet"
p.PROJ4 = "+proj=longlat +a=6378403.701 +b=6357018.120942386 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Nobles"
p.PROJ4 = "+proj=longlat +a=6378624.681 +b=6357238.360038281 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Norman"
p.PROJ4 = "+proj=longlat +a=6378468.623 +b=6357082.825271211 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Olmsted"
p.PROJ4 = "+proj=longlat +a=6378481.425 +b=6357095.584348529 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Ottertail"
p.PROJ4 = "+proj=longlat +a=6378525.621 +b=6357139.632167708 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Pennington"
p.PROJ4 = "+proj=longlat +a=6378445.763 +b=6357060.041916464 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Pine"
p.PROJ4 = "+proj=longlat +a=6378472.281 +b=6357086.47100663 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Pipestone"
p.PROJ4 = "+proj=longlat +a=6378670.401 +b=6357283.926747777 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Polk"
p.PROJ4 = "+proj=longlat +a=6378445.763 +b=6357060.041916464 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Pope"
p.PROJ4 = "+proj=longlat +a=6378502.761 +b=6357116.84881296 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Ramsey"
p.PROJ4 = "+proj=longlat +a=6378418.941 +b=6357033.309845551 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Red Lake"
p.PROJ4 = "+proj=longlat +a=6378445.763 +b=6357060.041916464 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Redwood"
p.PROJ4 = "+proj=longlat +a=6378438.753 +b=6357053.055419666 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Renville"
p.PROJ4 = "+proj=longlat +a=6378414.369 +b=6357028.753174601 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Rice"
p.PROJ4 = "+proj=longlat +a=6378434.181 +b=6357048.498748716 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Rock"
p.PROJ4 = "+proj=longlat +a=6378624.681 +b=6357238.360038281 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Roseau"
p.PROJ4 = "+proj=longlat +a=6378449.421 +b=6357063.687651882 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Scott"
p.PROJ4 = "+proj=longlat +a=6378421.989 +b=6357036.347626184 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Sherburne"
p.PROJ4 = "+proj=longlat +a=6378443.325 +b=6357057.612090616 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Sibley"
p.PROJ4 = "+proj=longlat +a=6378414.369 +b=6357028.753174601 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN St Louis Central"
p.PROJ4 = "+proj=longlat +a=6378605.783 +b=6357219.525399698 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN St Louis North"
p.PROJ4 = "+proj=longlat +a=6378543.909 +b=6357157.858851505 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN St Louis South"
p.PROJ4 = "+proj=longlat +a=6378540.861 +b=6357154.821070872 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Stearns"
p.PROJ4 = "+proj=longlat +a=6378502.761 +b=6357116.84881296 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Steele"
p.PROJ4 = "+proj=longlat +a=6378481.425 +b=6357095.584348529 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Stevens"
p.PROJ4 = "+proj=longlat +a=6378502.761 +b=6357116.84881296 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Swift"
p.PROJ4 = "+proj=longlat +a=6378470.757 +b=6357084.952116313 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Todd"
p.PROJ4 = "+proj=longlat +a=6378548.481 +b=6357162.415522455 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Traverse"
p.PROJ4 = "+proj=longlat +a=6378463.746 +b=6357077.964622869 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Wabasha"
p.PROJ4 = "+proj=longlat +a=6378426.561 +b=6357040.904297134 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Wadena"
p.PROJ4 = "+proj=longlat +a=6378546.957 +b=6357160.89663214 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Waseca"
p.PROJ4 = "+proj=longlat +a=6378481.425 +b=6357095.584348529 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Watonwan"
p.PROJ4 = "+proj=longlat +a=6378514.953 +b=6357128.999935492 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Winona"
p.PROJ4 = "+proj=longlat +a=6378453.688 +b=6357067.940345438 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Wright"
p.PROJ4 = "+proj=longlat +a=6378443.325 +b=6357057.612090616 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj MN Yellow Medicine"
p.PROJ4 = "+proj=longlat +a=6378530.193 +b=6357144.188838657 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Adams"
p.PROJ4 = "+proj=longlat +a=6378376.271 +b=6356991.5851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Ashland"
p.PROJ4 = "+proj=longlat +a=6378471.92 +b=6357087.2341403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Barron"
p.PROJ4 = "+proj=longlat +a=6378472.931 +b=6357088.2451403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Bayfield"
p.PROJ4 = "+proj=longlat +a=6378411.351 +b=6357026.6651403 +no_defs "
ProjectionList.Add(p)
        p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Buffalo"
p.PROJ4 = "+proj=longlat +a=6378380.991 +b=6356996.305140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Burnett"
p.PROJ4 = "+proj=longlat +a=6378414.96 +b=6357030.2741403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Calumet"
p.PROJ4 = "+proj=longlat +a=6378345.09 +b=6356960.4041403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Chippewa"
p.PROJ4 = "+proj=longlat +a=6378412.542 +b=6357027.856140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Clark"
p.PROJ4 = "+proj=longlat +a=6378470.401 +b=6357085.7151403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Columbia"
p.PROJ4 = "+proj=longlat +a=6378376.331 +b=6356991.645140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Crawford"
p.PROJ4 = "+proj=longlat +a=6378379.031 +b=6356994.345140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Dane"
p.PROJ4 = "+proj=longlat +a=6378407.621 +b=6357022.935140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Dodge"
p.PROJ4 = "+proj=longlat +a=6378376.811 +b=6356992.1251403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Door"
p.PROJ4 = "+proj=longlat +a=6378313.92 +b=6356929.2341403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Douglas"
p.PROJ4 = "+proj=longlat +a=6378414.93 +b=6357030.2441403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Dunn"
p.PROJ4 = "+proj=longlat +a=6378413.021 +b=6357028.3351403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI EauClaire"
p.PROJ4 = "+proj=longlat +a=6378380.381 +b=6356995.6951403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Florence"
p.PROJ4 = "+proj=longlat +a=6378530.851 +b=6357146.1651403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI FondduLac"
p.PROJ4 = "+proj=longlat +a=6378345.09 +b=6356960.4041403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Forest"
p.PROJ4 = "+proj=longlat +a=6378591.521 +b=6357206.8351403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Grant"
p.PROJ4 = "+proj=longlat +a=6378378.881 +b=6356994.1951403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Green"
p.PROJ4 = "+proj=longlat +a=6378408.481 +b=6357023.7951403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI GreenLake"
p.PROJ4 = "+proj=longlat +a=6378375.601 +b=6356990.9151403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Iowa"
p.PROJ4 = "+proj=longlat +a=6378408.041 +b=6357023.355140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Iron"
p.PROJ4 = "+proj=longlat +a=6378655.071000001 +b=6357270.385140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Jackson"
p.PROJ4 = "+proj=longlat +a=6378409.151 +b=6357024.4651403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Jefferson"
p.PROJ4 = "+proj=longlat +a=6378376.811 +b=6356992.1251403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Juneau"
p.PROJ4 = "+proj=longlat +a=6378376.271 +b=6356991.5851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Kenosha"
p.PROJ4 = "+proj=longlat +a=6378315.7 +b=6356931.014140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Kewaunee"
p.PROJ4 = "+proj=longlat +a=6378285.86 +b=6356901.174140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI LaCrosse"
p.PROJ4 = "+proj=longlat +a=6378379.301 +b=6356994.6151403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Lafayette"
p.PROJ4 = "+proj=longlat +a=6378408.481 +b=6357023.7951403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Langlade"
p.PROJ4 = "+proj=longlat +a=6378560.121 +b=6357175.435140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Lincoln"
p.PROJ4 = "+proj=longlat +a=6378531.821000001 +b=6357147.135140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Manitowoc"
p.PROJ4 = "+proj=longlat +a=6378285.86 +b=6356901.174140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Marathon"
p.PROJ4 = "+proj=longlat +a=6378500.6 +b=6357115.9141403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Marinette"
p.PROJ4 = "+proj=longlat +a=6378376.041 +b=6356991.355140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Marquette"
p.PROJ4 = "+proj=longlat +a=6378375.601 +b=6356990.9151403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Menominee"
p.PROJ4 = "+proj=longlat +a=6378406.601 +b=6357021.9151403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Milwaukee"
p.PROJ4 = "+proj=longlat +a=6378315.7 +b=6356931.014140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Monroe"
p.PROJ4 = "+proj=longlat +a=6378438.991 +b=6357054.305140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Oconto"
p.PROJ4 = "+proj=longlat +a=6378345.42 +b=6356960.7341403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Oneida"
p.PROJ4 = "+proj=longlat +a=6378593.86 +b=6357209.174140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Outagamie"
p.PROJ4 = "+proj=longlat +a=6378345.09 +b=6356960.4041403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Ozaukee"
p.PROJ4 = "+proj=longlat +a=6378315.7 +b=6356931.014140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Pepin"
p.PROJ4 = "+proj=longlat +a=6378381.271 +b=6356996.5851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Pierce"
p.PROJ4 = "+proj=longlat +a=6378381.271 +b=6356996.5851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Polk"
p.PROJ4 = "+proj=longlat +a=6378413.671 +b=6357028.9851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Portage"
p.PROJ4 = "+proj=longlat +a=6378344.377 +b=6356959.691139228 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Price"
p.PROJ4 = "+proj=longlat +a=6378563.891 +b=6357179.2051403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Racine"
p.PROJ4 = "+proj=longlat +a=6378315.7 +b=6356931.014140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Richland"
p.PROJ4 = "+proj=longlat +a=6378408.091 +b=6357023.4051403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Rock"
p.PROJ4 = "+proj=longlat +a=6378377.671 +b=6356992.9851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Rusk"
p.PROJ4 = "+proj=longlat +a=6378472.751 +b=6357088.0651403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Sauk"
p.PROJ4 = "+proj=longlat +a=6378407.281 +b=6357022.595140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Sawyer"
p.PROJ4 = "+proj=longlat +a=6378534.451 +b=6357149.765140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Shawano"
p.PROJ4 = "+proj=longlat +a=6378406.051 +b=6357021.3651403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Sheboygan"
p.PROJ4 = "+proj=longlat +a=6378285.86 +b=6356901.174140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI StCroix"
p.PROJ4 = "+proj=longlat +a=6378412.511 +b=6357027.8251403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Taylor"
p.PROJ4 = "+proj=longlat +a=6378532.921 +b=6357148.2351403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Trempealeau"
p.PROJ4 = "+proj=longlat +a=6378380.091 +b=6356995.4051403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Vernon"
p.PROJ4 = "+proj=longlat +a=6378408.941 +b=6357024.2551403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Vilas"
p.PROJ4 = "+proj=longlat +a=6378624.171 +b=6357239.4851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Walworth"
p.PROJ4 = "+proj=longlat +a=6378377.411 +b=6356992.725140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Washburn"
p.PROJ4 = "+proj=longlat +a=6378474.591 +b=6357089.9051403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Washington"
p.PROJ4 = "+proj=longlat +a=6378407.141 +b=6357022.4551403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Waukesha"
p.PROJ4 = "+proj=longlat +a=6378376.871 +b=6356992.185140301 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Waupaca"
p.PROJ4 = "+proj=longlat +a=6378375.251 +b=6356990.5651403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Waushara"
p.PROJ4 = "+proj=longlat +a=6378405.971 +b=6357021.2851403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Winnebago"
p.PROJ4 = "+proj=longlat +a=6378345.09 +b=6356960.4041403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "County Systems"
p.Name = "NAD 1983 HARN Adj WI Wood"
p.PROJ4 = "+proj=longlat +a=6378437.651 +b=6357052.9651403 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Albanian 1987"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Europe"
        p.Name = "Dutch RD"
        p.PROJ4 = "+proj=sterea +lat_0=52.15616055999986 +lon_0=5.387638888999871 +k=0.999908 +x_0=155000 +y_0=463000 +ellps=bessel +units=m +no_defs"
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
        p.Name = "Dutch RD"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "ATF (Paris)"
p.PROJ4 = "+proj=longlat +a=6376523 +b=6355862.933255573 +pm=2.337229166666667 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Belge 1950 (Brussels)"
p.PROJ4 = "+proj=longlat +ellps=intl +pm=4.367975 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Belge 1972"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Bern 1898 (Bern)"
p.PROJ4 = "+proj=longlat +ellps=bessel +pm=7.439583333333333 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Bern 1898"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Bern 1938"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "CH1903+"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "CH1903"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Datum 73"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Datum Lisboa Bessel"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Datum Lisboa Hayford"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Dealul Piscului 1933 (Romania)"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Dealul Piscului 1970 (Romania)"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Deutsche Hauptdreiecksnetz"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Estonia 1937"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
        p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Estonia 1997"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "ETRF 1989"
p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "ETRS 1989"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "EUREF FIN"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "European 1979"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "European Datum 1950"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "European Datum 1987"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Greek (Athens)"
p.PROJ4 = "+proj=longlat +ellps=bessel +pm=23.7163375 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Greek"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Greek_Geodetic_Ref._System_1987"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Hermannskogel"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Hjorsey 1955"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Hungarian Datum 1972"
p.PROJ4 = "+proj=longlat +ellps=GRS67 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "IRENET95"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "ISN 1993"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Kartastokoordinaattijarjestelma"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Lisbon (Lisbon)"
p.PROJ4 = "+proj=longlat +ellps=intl +pm=-9.131906111111112 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Lisbon 1890 (Lisbon)"
p.PROJ4 = "+proj=longlat +ellps=bessel +pm=-9.131906111111112 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Lisbon 1890"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Lisbon"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "LKS 1992"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "LKS 1994"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Luxembourg 1930"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Madrid 1870 (Madrid)"
p.PROJ4 = "+proj=longlat +a=6378298.3 +b=6356657.142669561 +pm=-3.687938888888889 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "MGI (Ferro)"
p.PROJ4 = "+proj=longlat +ellps=bessel +pm=-17.66666666666667 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Militar-Geographische Institut"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Monte Mario (Rome)"
p.PROJ4 = "+proj=longlat +ellps=intl +pm=12.45233333333333 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Monte Mario"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "NGO 1948 (Oslo)"
p.PROJ4 = "+proj=longlat +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "NGO 1948"
p.PROJ4 = "+proj=longlat +a=6377492.018 +b=6356173.508712696 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Nord de Guerre (Paris)"
p.PROJ4 = "+proj=longlat +a=6376523 +b=6355862.933255573 +pm=2.337229166666667 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Nouvelle Triangulation Francaise"
p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "NTF (Paris)"
p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "OS (SN) 1980"
p.PROJ4 = "+proj=longlat +ellps=airy +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "OSGB 1936"
p.PROJ4 = "+proj=longlat +ellps=airy +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "OSGB 1970 (SN)"
p.PROJ4 = "+proj=longlat +ellps=airy +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "OSNI 1952"
p.PROJ4 = "+proj=longlat +ellps=airy +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Pulkovo 1942 Adj 1958"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Pulkovo 1942 Adj 1983"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Pulkovo 1942"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Pulkovo 1995"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Qornoq"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Reseau National Belge 1950"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Reseau National Belge 1972"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Reykjavik 1900"
p.PROJ4 = "+proj=longlat +a=6377019.27 +b=6355762.5391 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "RGF 1993"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Roma 1940"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "RT 1990"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "RT38 (Stockholm)"
p.PROJ4 = "+proj=longlat +ellps=bessel +pm=18.05827777777778 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "RT38"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "S-42 Hungary"
p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "S-JTSK"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "SWEREF99"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "Swiss TRF 1995"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "TM65"
p.PROJ4 = "+proj=longlat +a=6377340.189 +b=6356034.447938534 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Europe"
p.Name = "TM75"
p.PROJ4 = "+proj=longlat +a=6377340.189 +b=6356034.447938534 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Alaskan Islands"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "American Samoa 1962"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Ammassalik 1958"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "ATS 1977"
p.PROJ4 = "+proj=longlat +a=6378135 +b=6356750.304921594 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Barbados"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Bermuda 1957"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Bermuda 2000"
p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Cape Canaveral"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Guam 1963"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Helle 1954"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Jamaica 1875"
p.PROJ4 = "+proj=longlat +a=6378249.138 +b=6356514.959419348 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Jamaica 1969"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "NAD 1927 (CGQ77)"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "NAD 1927 (Definition 1976)"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "NAD Michigan"
p.PROJ4 = "+proj=longlat +a=6378450.047 +b=6356826.620025999 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "North American 1983 (CSRS98)"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "North American 1983 HARN"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "North American Datum 1927"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +datum=NAD27 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "North American Datum 1983"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +datum=NAD83 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Old Hawaiian"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Puerto Rico"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Qornoq 1927"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Qornoq"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "Scoresbysund 1952"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "St._George_Island"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "St._Lawrence_Island"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "North America"
p.Name = "St._Paul_Island"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Alaskan Islands"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "American Samoa 1962"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Anguilla 1957"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Anna 1 Astro 1965"
p.PROJ4 = "+proj=longlat +ellps=aust_SA +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Antigua 1943"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Ascension Island 1958"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Astro Beacon E 1945"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Astro DOS 71-4"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Astronomical Station 1952"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Azores Central 1948"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Azores Central 1995"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Azores Occidental 1939"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Azores Oriental 1940"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Azores Oriental 1995"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Bab South"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Barbados 1938"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Barbados"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Bellevue IGN"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Bermuda 1957"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Bermuda 2000"
p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Canton Astro 1966"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Chatham Island Astro 1971"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Combani 1950"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "CSG 1967"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Dominica 1945"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "DOS 1968"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Easter Island 1967"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Fort Desaix"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Fort Marigot"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Fort Thomas 1955"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Gan 1970"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Graciosa Base SW 1948"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Grand Comoros"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Grenada 1953"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Guam 1963"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "GUX 1 Astro"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Hjorsey 1955"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "IGN53 Mare"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "IGN56 Lifou"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "IGN72 Grande Terre"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "IGN72 Nuku Hiva"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "ISTS 061 Astro 1968"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "ISTS 073 Astro 1969"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Jamaica 1875"
p.PROJ4 = "+proj=longlat +a=6378249.138 +b=6356514.959419348 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Jamaica 1969"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Johnston Island 1961"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "K0 1949"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Kerguelen Island 1949"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Kusaie Astro 1951"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "L.C. 5 Astro 1961"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Madeira 1936"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Mahe 1971"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Majuro"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Midway Astro 1961"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Montserrat 1958"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "MOP78"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "NEA74 Noumea"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Observ._Meteorologico_1939"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Old Hawaiian"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Pico de Las Nieves"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Pitcairn Astro 1967"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Piton des Neiges"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Pohnpei"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Porto Santo 1936"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Porto Santo 1995"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Puerto Rico"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Reunion"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "RGFG 1995"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "RGNC 1991"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "RGR 1992"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "RRAF 1991"
p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Saint Pierre et Miquelon 1950"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Sainte Anne"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Santo DOS 1965"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Sao Braz"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Sapper Hill 1943"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Selvagem Grande 1938"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "St._Kitts_1955"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "St._Lucia_1955"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "St._Vincent_1945"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "ST71 Belep"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "ST84 Ile des Pins"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "ST87 Ouvea"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Tahaa"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Tahiti"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Tern Island Astro 1961"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Tristan Astro 1968"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Viti Levu 1916"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Wake Island Astro 1952"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Oceans"
p.Name = "Wake-Eniwetok 1960"
p.PROJ4 = "+proj=longlat +a=6378270 +b=6356794.343434343 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Adrastea 2000"
p.PROJ4 = "+proj=longlat +a=8200 +b=8200 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Amalthea 2000"
p.PROJ4 = "+proj=longlat +a=83500 +b=83500 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Ananke 2000"
p.PROJ4 = "+proj=longlat +a=10000 +b=10000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Ariel 2000"
p.PROJ4 = "+proj=longlat +a=578900 +b=578900 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Atlas 2000"
p.PROJ4 = "+proj=longlat +a=16000 +b=16000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Belinda 2000"
p.PROJ4 = "+proj=longlat +a=33000 +b=33000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Bianca 2000"
p.PROJ4 = "+proj=longlat +a=21000 +b=21000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Callisto 2000"
p.PROJ4 = "+proj=longlat +a=2409300 +b=2409300 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Calypso 2000"
p.PROJ4 = "+proj=longlat +a=9500 +b=9500 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Carme 2000"
p.PROJ4 = "+proj=longlat +a=15000 +b=15000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Charon 2000"
p.PROJ4 = "+proj=longlat +a=593000 +b=593000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Cordelia 2000"
p.PROJ4 = "+proj=longlat +a=13000 +b=13000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Cressida 2000"
p.PROJ4 = "+proj=longlat +a=31000 +b=31000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Deimos 2000"
p.PROJ4 = "+proj=longlat +a=6200 +b=6200 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Desdemona 2000"
p.PROJ4 = "+proj=longlat +a=27000 +b=27000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Despina 2000"
p.PROJ4 = "+proj=longlat +a=74000 +b=74000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Dione 2000"
p.PROJ4 = "+proj=longlat +a=560000 +b=560000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Elara 2000"
p.PROJ4 = "+proj=longlat +a=40000 +b=40000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Enceladus 2000"
p.PROJ4 = "+proj=longlat +a=249400 +b=249400 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Epimetheus 2000"
p.PROJ4 = "+proj=longlat +a=59500 +b=59500 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Europa 2000"
p.PROJ4 = "+proj=longlat +a=1562090 +b=1562090 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Galatea 2000"
p.PROJ4 = "+proj=longlat +a=79000 +b=79000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Ganymede 2000"
p.PROJ4 = "+proj=longlat +a=2632345 +b=2632345 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Helene 2000"
p.PROJ4 = "+proj=longlat +a=17500 +b=700.0000000000046 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Himalia 2000"
p.PROJ4 = "+proj=longlat +a=85000 +b=85000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Hyperion 2000"
p.PROJ4 = "+proj=longlat +a=133000 +b=133000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Iapetus 2000"
p.PROJ4 = "+proj=longlat +a=718000 +b=718000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Io 2000"
p.PROJ4 = "+proj=longlat +a=1821460 +b=1821460 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Janus 2000"
p.PROJ4 = "+proj=longlat +a=888000 +b=888000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Juliet 2000"
p.PROJ4 = "+proj=longlat +a=42000 +b=42000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Jupiter 2000"
p.PROJ4 = "+proj=longlat +a=71492000 +b=66853999.99999999 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Larissa 2000"
p.PROJ4 = "+proj=longlat +a=104000 +b=89000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Leda 2000"
p.PROJ4 = "+proj=longlat +a=5000 +b=5000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Lysithea 2000"
p.PROJ4 = "+proj=longlat +a=12000 +b=12000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Mars 1979"
p.PROJ4 = "+proj=longlat +a=3393400 +b=3375730 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Mars 2000"
p.PROJ4 = "+proj=longlat +a=3396190 +b=3376200 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Mercury 2000"
p.PROJ4 = "+proj=longlat +a=2439700 +b=2439700 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Metis 2000"
p.PROJ4 = "+proj=longlat +a=30000 +b=20000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Mimas 2000"
p.PROJ4 = "+proj=longlat +a=1986300 +b=1986300 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Miranda 2000"
p.PROJ4 = "+proj=longlat +a=235800 +b=235800 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Moon 2000"
p.PROJ4 = "+proj=longlat +a=1737400 +b=1737400 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Naiad 2000"
p.PROJ4 = "+proj=longlat +a=29000 +b=29000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Neptune 2000"
p.PROJ4 = "+proj=longlat +a=24764000 +b=24341000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Nereid 2000"
p.PROJ4 = "+proj=longlat +a=170000 +b=170000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Oberon 2000"
p.PROJ4 = "+proj=longlat +a=761400 +b=761400 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Ophelia 2000"
p.PROJ4 = "+proj=longlat +a=15000 +b=15000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Pan 2000"
p.PROJ4 = "+proj=longlat +a=10000 +b=10000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Pandora 2000"
p.PROJ4 = "+proj=longlat +a=41900 +b=41900 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Pasiphae 2000"
p.PROJ4 = "+proj=longlat +a=18000 +b=18000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Phobos 2000"
p.PROJ4 = "+proj=longlat +a=11100 +b=11100 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Phoebe 2000"
p.PROJ4 = "+proj=longlat +a=110000 +b=110000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Pluto 2000"
p.PROJ4 = "+proj=longlat +a=1195000 +b=1195000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Portia 2000"
p.PROJ4 = "+proj=longlat +a=54000 +b=54000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Prometheus 2000"
p.PROJ4 = "+proj=longlat +a=50100 +b=50100 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Proteus 2000"
p.PROJ4 = "+proj=longlat +a=208000 +b=208000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Puck 2000"
p.PROJ4 = "+proj=longlat +a=77000 +b=77000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Rhea 2000"
p.PROJ4 = "+proj=longlat +a=764000 +b=764000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Rosalind 2000"
p.PROJ4 = "+proj=longlat +a=27000 +b=27000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Saturn 2000"
p.PROJ4 = "+proj=longlat +a=60268000 +b=54364000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Sinope 2000"
p.PROJ4 = "+proj=longlat +a=14000 +b=14000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Telesto 2000"
p.PROJ4 = "+proj=longlat +a=11000 +b=11000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Tethys 2000"
p.PROJ4 = "+proj=longlat +a=529800 +b=529800 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Thalassa 2000"
p.PROJ4 = "+proj=longlat +a=40000 +b=40000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Thebe 2000"
p.PROJ4 = "+proj=longlat +a=49300 +b=49300 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Titan 2000"
p.PROJ4 = "+proj=longlat +a=2575000 +b=2575000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Titania 2000"
p.PROJ4 = "+proj=longlat +a=788900 +b=788900 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Triton 2000"
p.PROJ4 = "+proj=longlat +a=1352600 +b=1352600 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Umbriel 2000"
p.PROJ4 = "+proj=longlat +a=584700 +b=584700 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Uranus 2000"
p.PROJ4 = "+proj=longlat +a=25559000 +b=24973000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Venus 1985"
p.PROJ4 = "+proj=longlat +a=6051000 +b=6051000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Solar System"
p.Name = "Venus 2000"
p.PROJ4 = "+proj=longlat +a=6051800 +b=6051800 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Aratu"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Bogota (Bogota)"
p.PROJ4 = "+proj=longlat +ellps=intl +pm=-74.08091666666667 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Bogota"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Campo Inchauspe"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Chos Malal 1914"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Chua"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Corrego Alegre"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Guyane Francaise"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Hito XVIII 1963"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "La Canoa"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Lake"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Loma Quintana"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Mount Dillon"
p.PROJ4 = "+proj=longlat +a=6378293.639 +b=6356617.98149216 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Naparima 1955"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Naparima 1972"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Pampa del Castillo"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "POSGAR 1998"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "POSGAR"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Provisional_South_Amer"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "REGVEN"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Sapper Hill 1943"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "SIRGAS"
p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "South American Datum 1969"
p.PROJ4 = "+proj=longlat +ellps=aust_SA +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Trinidad 1903"
p.PROJ4 = "+proj=longlat +a=6378293.639 +b=6356617.98149216 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Yacare"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "South America"
p.Name = "Zanderij"
p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Airy 1830"
p.PROJ4 = "+proj=longlat +ellps=airy +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Airy modified"
p.PROJ4 = "+proj=longlat +a=6377340.189 +b=6356034.447938534 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Australian National"
p.PROJ4 = "+proj=longlat +ellps=aust_SA +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Authalic sphere (ARCINFO)"
p.PROJ4 = "+proj=longlat +a=6370997 +b=6370997 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Authalic sphere"
p.PROJ4 = "+proj=longlat +a=6371000 +b=6371000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Average Terrestrial System 1977"
p.PROJ4 = "+proj=longlat +a=6378135 +b=6356750.304921594 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Bessel 1841"
p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Bessel modified"
p.PROJ4 = "+proj=longlat +a=6377492.018 +b=6356173.508712696 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Bessel Namibia"
p.PROJ4 = "+proj=longlat +ellps=bess_nam +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1858"
p.PROJ4 = "+proj=longlat +a=6378293.639 +b=6356617.98149216 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1866 Michigan"
p.PROJ4 = "+proj=longlat +a=6378450.047 +b=6356826.620025999 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1866"
p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1880 (Arc)"
p.PROJ4 = "+proj=longlat +a=6378249.145 +b=6356514.966395495 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1880 (Benoit)"
p.PROJ4 = "+proj=longlat +a=6378300.79 +b=6356566.430000036 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1880 (IGN)"
p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1880 (RGS)"
p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1880 (SGA)"
p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.996941779 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Clarke 1880"
p.PROJ4 = "+proj=longlat +a=6378249.138 +b=6356514.959419348 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Everest (definition 1967)"
p.PROJ4 = "+proj=longlat +ellps=evrstSS +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Everest (definition 1975)"
p.PROJ4 = "+proj=longlat +a=6377301.243 +b=6356100.228368102 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Everest 1830"
p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Everest modified 1969"
p.PROJ4 = "+proj=longlat +a=6377295.664 +b=6356094.667915204 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Everest modified"
p.PROJ4 = "+proj=longlat +a=6377304.063 +b=6356103.041812424 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Fischer 1960"
p.PROJ4 = "+proj=longlat +a=6378166 +b=6356784.283607107 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Geographic Coordinate Systems"
p.Category = "Spheroid-based"
p.Name = "Fischer 1968"
p.PROJ4 = "+proj=longlat +a=6378150 +b=6356768.337244385 +no_defs "
ProjectionList.Add(p)
        p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Africa"
p.Name = "Africa Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=20 +lat_2=-23 +lat_0=0 +lon_0=25 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Africa"
p.Name = "Africa Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=20 +lat_2=-23 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Africa"
p.Name = "Africa Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=20 +lat_2=-23 +lat_0=0 +lon_0=25 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Africa"
p.Name = "Africa Sinusoidal"
p.PROJ4 = "+proj=sinu +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=30 +lat_2=62 +lat_0=0 +lon_0=105 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia North Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=15 +lat_2=65 +lat_0=30 +lon_0=95 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia North Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=15 +lat_2=65 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia North Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=15 +lat_2=65 +lat_0=30 +lon_0=95 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia South Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=7 +lat_2=-32 +lat_0=-15 +lon_0=125 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia South Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=7 +lat_2=-32 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Asia"
p.Name = "Asia South Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=7 +lat_2=-32 +lat_0=-15 +lon_0=125 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "EMEP 150 Kilometer Grid"
p.PROJ4 = "+a=6370000 +b=6370000 +to_meter=150000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "EMEP 50 Kilometer Grid"
p.PROJ4 = "+a=6370000 +b=6370000 +to_meter=50000 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "ETRS 1989 LAEA"
p.PROJ4 = "+proj=laea +lat_0=52 +lon_0=10 +x_0=4321000 +y_0=3210000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "ETRS 1989 LCC"
p.PROJ4 = "+proj=lcc +lat_1=35 +lat_2=65 +lat_0=52 +lon_0=10 +x_0=4000000 +y_0=2800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "Europe Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=43 +lat_2=62 +lat_0=30 +lon_0=10 +x_0=0 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "Europe Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=43 +lat_2=62 +x_0=0 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - Europe"
p.Name = "Europe Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=43 +lat_2=62 +lat_0=30 +lon_0=10 +x_0=0 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "Alaska Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=55 +lat_2=65 +lat_0=50 +lon_0=-154 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "Canada Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=50 +lat_2=70 +lat_0=40 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "Canada Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=50 +lat_2=70 +lat_0=40 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "Hawaii Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=8 +lat_2=18 +lat_0=13 +lon_0=-157 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "North America Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=20 +lat_2=60 +lat_0=40 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "North America Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=20 +lat_2=60 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "North America Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=20 +lat_2=60 +lat_0=40 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "USA Contiguous Albers Equal Area Conic USGS"
p.PROJ4 = "+proj=aea +lat_1=29.5 +lat_2=45.5 +lat_0=23 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "USA Contiguous Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=29.5 +lat_2=45.5 +lat_0=37.5 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "USA Contiguous Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=33 +lat_2=45 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - North America"
p.Name = "USA Contiguous Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=33 +lat_2=45 +lat_0=39 +lon_0=-96 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - South America"
p.Name = "South America Albers Equal Area Conic"
p.PROJ4 = "+proj=aea +lat_1=-5 +lat_2=-42 +lat_0=-32 +lon_0=-60 +x_0=0 +y_0=0 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - South America"
p.Name = "South America Equidistant Conic"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=-5 +lat_2=-42 +x_0=0 +y_0=0 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Continental - South America"
p.Name = "South America Lambert Conformal Conic"
p.PROJ4 = "+proj=lcc +lat_1=-5 +lat_2=-42 +lat_0=-32 +lon_0=-60 +x_0=0 +y_0=0 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Aitkin Feet"
p.PROJ4 = "+proj=tmerc +lat_0=46.15 +lon_0=-93.41666666666667 +k=1.000059 +x_0=152409.319685395 +y_0=30481.86393707899 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Aitkin Meters"
p.PROJ4 = "+proj=tmerc +lat_0=46.15 +lon_0=-93.41666666666667 +k=1.000059 +x_0=152409.319685395 +y_0=30481.86393707899 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Anoka Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.06666666666667 +lat_2=45.36666666666667 +lat_0=45.03333333333333 +lon_0=-93.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378418.941 +b=6357033.309845551 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Anoka Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.06666666666667 +lat_2=45.36666666666667 +lat_0=45.03333333333333 +lon_0=-93.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378418.941 +b=6357033.309845551 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Becker Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.78333333333333 +lat_2=47.08333333333334 +lat_0=46.71666666666667 +lon_0=-95.68333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378586.581 +b=6357200.387780368 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Becker Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.78333333333333 +lat_2=47.08333333333334 +lat_0=46.71666666666667 +lon_0=-95.68333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378586.581 +b=6357200.387780368 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Beltrami North Feet"
p.PROJ4 = "+proj=lcc +lat_1=48.11666666666667 +lat_2=48.46666666666667 +lat_0=48.01666666666667 +lon_0=-95.01666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378505.809 +b=6357119.886593593 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Beltrami North Meters"
p.PROJ4 = "+proj=lcc +lat_1=48.11666666666667 +lat_2=48.46666666666667 +lat_0=48.01666666666667 +lon_0=-95.01666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378505.809 +b=6357119.886593593 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Beltrami South Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=47.91666666666666 +lat_0=47.4 +lon_0=-94.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378544.823 +b=6357158.769787037 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Beltrami South Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=47.91666666666666 +lat_0=47.4 +lon_0=-94.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378544.823 +b=6357158.769787037 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Benton Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.58333333333334 +lat_2=45.78333333333333 +lat_0=45.55 +lon_0=-94.05 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378490.569 +b=6357104.697690427 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Benton Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.58333333333334 +lat_2=45.78333333333333 +lat_0=45.55 +lon_0=-94.05 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378490.569 +b=6357104.697690427 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Big Stone Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.21666666666667 +lat_2=45.53333333333333 +lat_0=45.15 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378470.757 +b=6357084.952116313 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Big Stone Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.21666666666667 +lat_2=45.53333333333333 +lat_0=45.15 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378470.757 +b=6357084.952116313 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Blue Earth Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.93333333333333 +lat_2=44.36666666666667 +lat_0=43.83333333333334 +lon_0=-94.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378403.701 +b=6357018.120942386 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Blue Earth Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.93333333333333 +lat_2=44.36666666666667 +lat_0=43.83333333333334 +lon_0=-94.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378403.701 +b=6357018.120942386 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Brown Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.16666666666666 +lat_2=44.46666666666667 +lat_0=44.1 +lon_0=-94.73333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378434.181 +b=6357048.498748716 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Brown Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.16666666666666 +lat_2=44.46666666666667 +lat_0=44.1 +lon_0=-94.73333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378434.181 +b=6357048.498748716 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Carlton Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.46666666666667 +lat_2=46.73333333333333 +lat_0=46.41666666666666 +lon_0=-92.68333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378454.907 +b=6357069.155258362 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Carlton Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.46666666666667 +lat_2=46.73333333333333 +lat_0=46.41666666666666 +lon_0=-92.68333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378454.907 +b=6357069.155258362 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Carver Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.68333333333333 +lat_2=44.9 +lat_0=44.63333333333333 +lon_0=-93.76666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378400.653 +b=6357015.083161753 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Carver Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.68333333333333 +lat_2=44.9 +lat_0=44.63333333333333 +lon_0=-93.76666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378400.653 +b=6357015.083161753 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cass North Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.91666666666666 +lat_2=47.31666666666667 +lat_0=46.8 +lon_0=-94.21666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378567.378 +b=6357181.249164391 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cass North Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.91666666666666 +lat_2=47.31666666666667 +lat_0=46.8 +lon_0=-94.21666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378567.378 +b=6357181.249164391 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cass South Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.26666666666667 +lat_2=46.73333333333333 +lat_0=46.15 +lon_0=-94.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378546.957 +b=6357160.89663214 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cass South Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.26666666666667 +lat_2=46.73333333333333 +lat_0=46.15 +lon_0=-94.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378546.957 +b=6357160.89663214 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Chippewa Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.83333333333334 +lat_2=45.2 +lat_0=44.75 +lon_0=-95.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378476.853 +b=6357091.027677579 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Chippewa Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.83333333333334 +lat_2=45.2 +lat_0=44.75 +lon_0=-95.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378476.853 +b=6357091.027677579 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Chisago Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.33333333333334 +lat_2=45.66666666666666 +lat_0=45.28333333333333 +lon_0=-93.08333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378411.321000001 +b=6357025.715393969 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Chisago Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.33333333333334 +lat_2=45.66666666666666 +lat_0=45.28333333333333 +lon_0=-93.08333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378411.321000001 +b=6357025.715393969 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Clay Feet"
p.PROJ4 = "+proj=tmerc +lat_0=46.61666666666667 +lon_0=-96.7 +k=1.000045 +x_0=152407.2112565913 +y_0=30481.44225131826 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Clay Meters"
p.PROJ4 = "+proj=tmerc +lat_0=46.61666666666667 +lon_0=-96.7 +k=1.000045 +x_0=152407.2112565913 +y_0=30481.44225131827 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Clearwater Feet"
p.PROJ4 = "+proj=tmerc +lat_0=47.15 +lon_0=-95.36666666666666 +k=1.000073 +x_0=152411.3546854458 +y_0=30482.27093708915 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Clearwater Meters"
p.PROJ4 = "+proj=tmerc +lat_0=47.15 +lon_0=-95.36666666666666 +k=1.000073 +x_0=152411.3546854458 +y_0=30482.27093708916 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cook North Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.93333333333333 +lat_2=48.16666666666666 +lat_0=47.88333333333333 +lon_0=-90.25 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378647.541 +b=6357261.14339303 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cook North Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.93333333333333 +lat_2=48.16666666666666 +lat_0=47.88333333333333 +lon_0=-90.25 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378647.541 +b=6357261.14339303 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cook South Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.55 +lat_2=47.81666666666667 +lat_0=47.43333333333333 +lon_0=-90.25 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378647.541 +b=6357261.14339303 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cook South Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.55 +lat_2=47.81666666666667 +lat_0=47.43333333333333 +lon_0=-90.25 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378647.541 +b=6357261.14339303 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cottonwood Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.9 +lat_2=44.16666666666666 +lat_0=43.83333333333334 +lon_0=-94.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378514.953 +b=6357128.999935492 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Cottonwood Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.9 +lat_2=44.16666666666666 +lat_0=43.83333333333334 +lon_0=-94.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378514.953 +b=6357128.999935492 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Crow Wing Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.26666666666667 +lat_2=46.73333333333333 +lat_0=46.15 +lon_0=-94.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378546.957 +b=6357160.89663214 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Crow Wing Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.26666666666667 +lat_2=46.73333333333333 +lat_0=46.15 +lon_0=-94.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378546.957 +b=6357160.89663214 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Dakota Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.51666666666667 +lat_2=44.91666666666666 +lat_0=44.46666666666667 +lon_0=-93.31666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378421.989 +b=6357036.347626184 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Dakota Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.51666666666667 +lat_2=44.91666666666666 +lat_0=44.46666666666667 +lon_0=-93.31666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378421.989 +b=6357036.347626184 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Dodge Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378481.425 +b=6357095.584348529 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Dodge Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378481.425 +b=6357095.584348529 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Douglas Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.8 +lat_2=46.05 +lat_0=45.75 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378518.001 +b=6357132.037716125 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Douglas Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.8 +lat_2=46.05 +lat_0=45.75 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378518.001 +b=6357132.037716125 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Faribault Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378521.049 +b=6357135.075496757 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Faribault Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378521.049 +b=6357135.075496757 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Fillmore Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.55 +lat_2=43.8 +lat_0=43.5 +lon_0=-92.08333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378464.661 +b=6357078.876555047 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Fillmore Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.55 +lat_2=43.8 +lat_0=43.5 +lon_0=-92.08333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378464.661 +b=6357078.876555047 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Freeborn Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378521.049 +b=6357135.075496757 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Freeborn Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378521.049 +b=6357135.075496757 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Goodhue Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.3 +lat_2=44.66666666666666 +lat_0=44.18333333333333 +lon_0=-93.13333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378434.181 +b=6357048.498748716 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Goodhue Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.3 +lat_2=44.66666666666666 +lat_0=44.18333333333333 +lon_0=-93.13333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378434.181 +b=6357048.498748716 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Grant Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.8 +lat_2=46.05 +lat_0=45.75 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378518.001 +b=6357132.037716125 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Grant Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.8 +lat_2=46.05 +lat_0=45.75 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378518.001 +b=6357132.037716125 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Hennepin Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.88333333333333 +lat_2=45.13333333333333 +lat_0=44.78333333333333 +lon_0=-93.38333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378418.941 +b=6357033.309845551 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Hennepin Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.88333333333333 +lat_2=45.13333333333333 +lat_0=44.78333333333333 +lon_0=-93.38333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378418.941 +b=6357033.309845551 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Houston Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-91.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378436.619 +b=6357050.928574564 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Houston Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-91.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378436.619 +b=6357050.928574564 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Hubbard Feet"
p.PROJ4 = "+proj=tmerc +lat_0=46.8 +lon_0=-94.91666666666667 +k=1.000072 +x_0=152411.2096003556 +y_0=30482.24192007112 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Hubbard Meters"
p.PROJ4 = "+proj=tmerc +lat_0=46.8 +lon_0=-94.91666666666667 +k=1.000072 +x_0=152411.2096003556 +y_0=30482.24192007113 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Isanti Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.33333333333334 +lat_2=45.66666666666666 +lat_0=45.28333333333333 +lon_0=-93.08333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378411.321000001 +b=6357025.715393969 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Isanti Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.33333333333334 +lat_2=45.66666666666666 +lat_0=45.28333333333333 +lon_0=-93.08333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378411.321000001 +b=6357025.715393969 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Itasca North Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.56666666666667 +lat_2=47.81666666666667 +lat_0=47.5 +lon_0=-93.73333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378574.389 +b=6357188.236657837 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Itasca North Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.56666666666667 +lat_2=47.81666666666667 +lat_0=47.5 +lon_0=-93.73333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378574.389 +b=6357188.236657837 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Itasca South Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.08333333333334 +lat_2=47.41666666666666 +lat_0=47.01666666666667 +lon_0=-93.73333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378574.389 +b=6357188.236657837 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Itasca South Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.08333333333334 +lat_2=47.41666666666666 +lat_0=47.01666666666667 +lon_0=-93.73333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378574.389 +b=6357188.236657837 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Jackson Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378521.049 +b=6357135.075496757 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Jackson Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378521.049 +b=6357135.075496757 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Kanabec Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.81666666666667 +lat_2=46.33333333333334 +lat_0=45.71666666666667 +lon_0=-92.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378472.281 +b=6357086.47100663 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Kanabec Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.81666666666667 +lat_2=46.33333333333334 +lat_0=45.71666666666667 +lon_0=-92.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378472.281 +b=6357086.47100663 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Kandiyohi Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.96666666666667 +lat_2=45.33333333333334 +lat_0=44.88333333333333 +lon_0=-94.75 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378498.189 +b=6357112.29214201 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Kandiyohi Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.96666666666667 +lat_2=45.33333333333334 +lat_0=44.88333333333333 +lon_0=-94.75 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378498.189 +b=6357112.29214201 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Kittson Feet"
p.PROJ4 = "+proj=lcc +lat_1=48.6 +lat_2=48.93333333333333 +lat_0=48.53333333333333 +lon_0=-96.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378449.421 +b=6357063.687651882 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Kittson Meters"
p.PROJ4 = "+proj=lcc +lat_1=48.6 +lat_2=48.93333333333333 +lat_0=48.53333333333333 +lon_0=-96.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378449.421 +b=6357063.687651882 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Koochiching Feet"
p.PROJ4 = "+proj=lcc +lat_1=48 +lat_2=48.61666666666667 +lat_0=47.83333333333334 +lon_0=-93.75 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378525.621 +b=6357139.632167708 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Koochiching Meters"
p.PROJ4 = "+proj=lcc +lat_1=48 +lat_2=48.61666666666667 +lat_0=47.83333333333334 +lon_0=-93.75 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378525.621 +b=6357139.632167708 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lac Qui Parle Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.83333333333334 +lat_2=45.2 +lat_0=44.75 +lon_0=-95.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378476.853 +b=6357091.027677579 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lac Qui Parle Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.83333333333334 +lat_2=45.2 +lat_0=44.75 +lon_0=-95.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378476.853 +b=6357091.027677579 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lake Feet"
p.PROJ4 = "+proj=tmerc +lat_0=47.06666666666667 +lon_0=-91.40000000000001 +k=1.000076 +x_0=152411.8635439675 +y_0=30482.3727087935 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lake Meters"
p.PROJ4 = "+proj=tmerc +lat_0=47.06666666666667 +lon_0=-91.40000000000001 +k=1.000076 +x_0=152411.8635439675 +y_0=30482.3727087935 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lake of the Woods North Feet"
p.PROJ4 = "+proj=lcc +lat_1=49.18333333333333 +lat_2=49.33333333333334 +lat_0=49.15 +lon_0=-94.98333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378466.185 +b=6357080.395445363 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lake of the Woods North Meters"
p.PROJ4 = "+proj=lcc +lat_1=49.18333333333333 +lat_2=49.33333333333334 +lat_0=49.15 +lon_0=-94.98333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378466.185 +b=6357080.395445363 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lake of the Woods South Feet"
p.PROJ4 = "+proj=lcc +lat_1=48.45 +lat_2=48.88333333333333 +lat_0=48.35 +lon_0=-94.88333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378496.665 +b=6357110.773251694 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lake of the Woods South Meters"
p.PROJ4 = "+proj=lcc +lat_1=48.45 +lat_2=48.88333333333333 +lat_0=48.35 +lon_0=-94.88333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378496.665 +b=6357110.773251694 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Le Sueur Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.3 +lat_2=44.66666666666666 +lat_0=44.18333333333333 +lon_0=-93.13333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378434.181 +b=6357048.498748716 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Le Sueur Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.3 +lat_2=44.66666666666666 +lat_0=44.18333333333333 +lon_0=-93.13333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378434.181 +b=6357048.498748716 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lincoln Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.28333333333333 +lat_2=44.61666666666667 +lat_0=44.18333333333333 +lon_0=-96.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378643.579 +b=6357257.194676865 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lincoln Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.28333333333333 +lat_2=44.61666666666667 +lat_0=44.18333333333333 +lon_0=-96.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378643.579 +b=6357257.194676865 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lyon Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=44.58333333333334 +lat_0=44.18333333333333 +lon_0=-95.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378559.758 +b=6357173.65471281 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Lyon Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=44.58333333333334 +lat_0=44.18333333333333 +lon_0=-95.84999999999999 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378559.758 +b=6357173.65471281 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Mahnomen Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.2 +lat_2=47.45 +lat_0=47.15 +lon_0=-95.81666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378586.581 +b=6357200.387780368 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Mahnomen Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.2 +lat_2=47.45 +lat_0=47.15 +lon_0=-95.81666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378586.581 +b=6357200.387780368 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Marshall Feet"
p.PROJ4 = "+proj=lcc +lat_1=48.23333333333333 +lat_2=48.48333333333333 +lat_0=48.16666666666666 +lon_0=-96.38333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378441.801 +b=6357056.093200299 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Marshall Meters"
p.PROJ4 = "+proj=lcc +lat_1=48.23333333333333 +lat_2=48.48333333333333 +lat_0=48.16666666666666 +lon_0=-96.38333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378441.801 +b=6357056.093200299 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Martin Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378521.049 +b=6357135.075496757 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Martin Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378521.049 +b=6357135.075496757 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN McLeod Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.53333333333333 +lat_2=44.91666666666666 +lat_0=44.45 +lon_0=-94.63333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378414.369 +b=6357028.753174601 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN McLeod Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.53333333333333 +lat_2=44.91666666666666 +lat_0=44.45 +lon_0=-94.63333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378414.369 +b=6357028.753174601 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Meeker Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.96666666666667 +lat_2=45.33333333333334 +lat_0=44.88333333333333 +lon_0=-94.75 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378498.189 +b=6357112.29214201 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Meeker Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.96666666666667 +lat_2=45.33333333333334 +lat_0=44.88333333333333 +lon_0=-94.75 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378498.189 +b=6357112.29214201 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Mille Lacs Feet"
p.PROJ4 = "+proj=tmerc +lat_0=45.55 +lon_0=-93.61666666666666 +k=1.000054 +x_0=152408.5566885446 +y_0=30481.71133770892 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Mille Lacs Meters"
p.PROJ4 = "+proj=tmerc +lat_0=45.55 +lon_0=-93.61666666666666 +k=1.000054 +x_0=152408.5566885446 +y_0=30481.71133770892 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Morrison Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.85 +lat_2=46.26666666666667 +lat_0=45.76666666666667 +lon_0=-94.2 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378502.761 +b=6357116.84881296 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Morrison Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.85 +lat_2=46.26666666666667 +lat_0=45.76666666666667 +lon_0=-94.2 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378502.761 +b=6357116.84881296 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Mower Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378521.049 +b=6357135.075496757 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Mower Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-93.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378521.049 +b=6357135.075496757 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Murray Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.91666666666666 +lat_2=44.16666666666666 +lat_0=43.83333333333334 +lon_0=-95.76666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378617.061 +b=6357230.765586698 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Murray Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.91666666666666 +lat_2=44.16666666666666 +lat_0=43.83333333333334 +lon_0=-95.76666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378617.061 +b=6357230.765586698 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Nicollet Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.93333333333333 +lat_2=44.36666666666667 +lat_0=43.83333333333334 +lon_0=-94.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378403.701 +b=6357018.120942386 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Nicollet Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.93333333333333 +lat_2=44.36666666666667 +lat_0=43.83333333333334 +lon_0=-94.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378403.701 +b=6357018.120942386 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Nobles Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-95.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378624.681 +b=6357238.360038281 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Nobles Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-95.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378624.681 +b=6357238.360038281 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Norman Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.2 +lat_2=47.45 +lat_0=47.15 +lon_0=-96.45 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378468.623 +b=6357082.825271211 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Norman Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.2 +lat_2=47.45 +lat_0=47.15 +lon_0=-96.45 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378468.623 +b=6357082.825271211 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Olmsted Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378481.425 +b=6357095.584348529 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Olmsted Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378481.425 +b=6357095.584348529 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Ottertail Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=46.65 +lat_0=46.1 +lon_0=-95.71666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378525.621 +b=6357139.632167708 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Ottertail Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=46.65 +lat_0=46.1 +lon_0=-95.71666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378525.621 +b=6357139.632167708 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pennington Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.6 +lat_2=48.08333333333334 +lat_0=47.48333333333333 +lon_0=-96.36666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378445.763 +b=6357060.041916464 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pennington Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.6 +lat_2=48.08333333333334 +lat_0=47.48333333333333 +lon_0=-96.36666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378445.763 +b=6357060.041916464 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pine Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.81666666666667 +lat_2=46.33333333333334 +lat_0=45.71666666666667 +lon_0=-92.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378472.281 +b=6357086.47100663 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pine Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.81666666666667 +lat_2=46.33333333333334 +lat_0=45.71666666666667 +lon_0=-92.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378472.281 +b=6357086.47100663 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pipestone Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.15 +lat_0=43.83333333333334 +lon_0=-96.25 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378670.401 +b=6357283.926747777 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pipestone Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.15 +lat_0=43.83333333333334 +lon_0=-96.25 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378670.401 +b=6357283.926747777 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Polk Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.6 +lat_2=48.08333333333334 +lat_0=47.48333333333333 +lon_0=-96.36666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378445.763 +b=6357060.041916464 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Polk Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.6 +lat_2=48.08333333333334 +lat_0=47.48333333333333 +lon_0=-96.36666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378445.763 +b=6357060.041916464 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pope Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.35 +lat_2=45.7 +lat_0=45.26666666666667 +lon_0=-95.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378502.761 +b=6357116.84881296 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Pope Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.35 +lat_2=45.7 +lat_0=45.26666666666667 +lon_0=-95.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378502.761 +b=6357116.84881296 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Ramsey Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.88333333333333 +lat_2=45.13333333333333 +lat_0=44.78333333333333 +lon_0=-93.38333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378418.941 +b=6357033.309845551 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Ramsey Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.88333333333333 +lat_2=45.13333333333333 +lat_0=44.78333333333333 +lon_0=-93.38333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378418.941 +b=6357033.309845551 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Red Lake Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.6 +lat_2=48.08333333333334 +lat_0=47.48333333333333 +lon_0=-96.36666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378445.763 +b=6357060.041916464 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Red Lake Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.6 +lat_2=48.08333333333334 +lat_0=47.48333333333333 +lon_0=-96.36666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378445.763 +b=6357060.041916464 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Redwood Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.26666666666667 +lat_2=44.56666666666667 +lat_0=44.18333333333333 +lon_0=-95.23333333333333 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378438.753 +b=6357053.055419666 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Redwood Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.26666666666667 +lat_2=44.56666666666667 +lat_0=44.18333333333333 +lon_0=-95.23333333333333 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378438.753 +b=6357053.055419666 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Renville Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.53333333333333 +lat_2=44.91666666666666 +lat_0=44.45 +lon_0=-94.63333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378414.369 +b=6357028.753174601 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Renville Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.53333333333333 +lat_2=44.91666666666666 +lat_0=44.45 +lon_0=-94.63333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378414.369 +b=6357028.753174601 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Rice Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.3 +lat_2=44.66666666666666 +lat_0=44.18333333333333 +lon_0=-93.13333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378434.181 +b=6357048.498748716 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Rice Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.3 +lat_2=44.66666666666666 +lat_0=44.18333333333333 +lon_0=-93.13333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378434.181 +b=6357048.498748716 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Rock Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-95.95 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378624.681 +b=6357238.360038281 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Rock Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.56666666666667 +lat_2=43.8 +lat_0=43.5 +lon_0=-95.95 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378624.681 +b=6357238.360038281 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Roseau Feet"
p.PROJ4 = "+proj=lcc +lat_1=48.6 +lat_2=48.93333333333333 +lat_0=48.53333333333333 +lon_0=-96.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378449.421 +b=6357063.687651882 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Roseau Meters"
p.PROJ4 = "+proj=lcc +lat_1=48.6 +lat_2=48.93333333333333 +lat_0=48.53333333333333 +lon_0=-96.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378449.421 +b=6357063.687651882 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Scott Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.51666666666667 +lat_2=44.91666666666666 +lat_0=44.46666666666667 +lon_0=-93.31666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378421.989 +b=6357036.347626184 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Scott Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.51666666666667 +lat_2=44.91666666666666 +lat_0=44.46666666666667 +lon_0=-93.31666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378421.989 +b=6357036.347626184 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Sherburne Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.03333333333333 +lat_2=45.46666666666667 +lat_0=44.96666666666667 +lon_0=-93.88333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378443.325 +b=6357057.612090616 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Sherburne Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.03333333333333 +lat_2=45.46666666666667 +lat_0=44.96666666666667 +lon_0=-93.88333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378443.325 +b=6357057.612090616 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Sibley Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.53333333333333 +lat_2=44.91666666666666 +lat_0=44.45 +lon_0=-94.63333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378414.369 +b=6357028.753174601 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Sibley Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.53333333333333 +lat_2=44.91666666666666 +lat_0=44.45 +lon_0=-94.63333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378414.369 +b=6357028.753174601 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN St Louis Central Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.33333333333334 +lat_2=47.75 +lat_0=47.25 +lon_0=-92.45 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378605.783 +b=6357219.525399698 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN St Louis Central Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.33333333333334 +lat_2=47.75 +lat_0=47.25 +lon_0=-92.45 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378605.783 +b=6357219.525399698 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN St Louis North Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.98333333333333 +lat_2=48.53333333333333 +lat_0=47.83333333333334 +lon_0=-92.45 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378543.909 +b=6357157.858851505 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN St Louis North Meters"
p.PROJ4 = "+proj=lcc +lat_1=47.98333333333333 +lat_2=48.53333333333333 +lat_0=47.83333333333334 +lon_0=-92.45 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378543.909 +b=6357157.858851505 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN St Louis South Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.78333333333333 +lat_2=47.13333333333333 +lat_0=46.65 +lon_0=-92.45 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378540.861 +b=6357154.821070872 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN St Louis South Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.78333333333333 +lat_2=47.13333333333333 +lat_0=46.65 +lon_0=-92.45 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378540.861 +b=6357154.821070872 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Stearns Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.35 +lat_2=45.7 +lat_0=45.26666666666667 +lon_0=-95.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378502.761 +b=6357116.84881296 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Stearns Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.35 +lat_2=45.7 +lat_0=45.26666666666667 +lon_0=-95.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378502.761 +b=6357116.84881296 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Steele Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378481.425 +b=6357095.584348529 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Steele Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378481.425 +b=6357095.584348529 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Stevens Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.35 +lat_2=45.7 +lat_0=45.26666666666667 +lon_0=-95.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378502.761 +b=6357116.84881296 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Stevens Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.35 +lat_2=45.7 +lat_0=45.26666666666667 +lon_0=-95.15000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378502.761 +b=6357116.84881296 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Swift Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.21666666666667 +lat_2=45.53333333333333 +lat_0=45.15 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378470.757 +b=6357084.952116313 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Swift Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.21666666666667 +lat_2=45.53333333333333 +lat_0=45.15 +lon_0=-96.05 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378470.757 +b=6357084.952116313 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Todd Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.86666666666667 +lat_2=46.28333333333333 +lat_0=45.76666666666667 +lon_0=-94.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378548.481 +b=6357162.415522455 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Todd Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.86666666666667 +lat_2=46.28333333333333 +lat_0=45.76666666666667 +lon_0=-94.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378548.481 +b=6357162.415522455 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Traverse Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.63333333333333 +lat_2=45.96666666666667 +lat_0=45.58333333333334 +lon_0=-96.55 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378463.746 +b=6357077.964622869 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Traverse Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.63333333333333 +lat_2=45.96666666666667 +lat_0=45.58333333333334 +lon_0=-96.55 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378463.746 +b=6357077.964622869 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wabasha Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.15 +lat_2=44.41666666666666 +lat_0=44.1 +lon_0=-92.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378426.561 +b=6357040.904297134 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wabasha Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.15 +lat_2=44.41666666666666 +lat_0=44.1 +lon_0=-92.26666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378426.561 +b=6357040.904297134 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wadena Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.26666666666667 +lat_2=46.73333333333333 +lat_0=46.15 +lon_0=-94.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378546.957 +b=6357160.89663214 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wadena Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.26666666666667 +lat_2=46.73333333333333 +lat_0=46.15 +lon_0=-94.46666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378546.957 +b=6357160.89663214 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Waseca Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378481.425 +b=6357095.584348529 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Waseca Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.88333333333333 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-92.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378481.425 +b=6357095.584348529 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Washington Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.73333333333333 +lon_0=-92.83333333333333 +k=1.000040 +x_0=152406.3759409195 +y_0=30481.2751881839 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Washington Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.73333333333333 +lon_0=-92.83333333333333 +k=1.000040 +x_0=152406.3759409195 +y_0=30481.2751881839 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Watonwan Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.9 +lat_2=44.16666666666666 +lat_0=43.83333333333334 +lon_0=-94.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378514.953 +b=6357128.999935492 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Watonwan Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.9 +lat_2=44.16666666666666 +lat_0=43.83333333333334 +lon_0=-94.91666666666667 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378514.953 +b=6357128.999935492 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wilkin Feet"
p.PROJ4 = "+proj=tmerc +lat_0=46.01666666666667 +lon_0=-96.51666666666667 +k=1.000049 +x_0=152407.7573379731 +y_0=30481.55146759461 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wilkin Meters"
p.PROJ4 = "+proj=tmerc +lat_0=46.01666666666667 +lon_0=-96.51666666666667 +k=1.000049 +x_0=152407.7573379731 +y_0=30481.55146759462 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Winona Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.9 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-91.61666666666666 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378453.688 +b=6357067.940345438 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Winona Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.9 +lat_2=44.13333333333333 +lat_0=43.83333333333334 +lon_0=-91.61666666666666 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378453.688 +b=6357067.940345438 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wright Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.03333333333333 +lat_2=45.46666666666667 +lat_0=44.96666666666667 +lon_0=-93.88333333333334 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378443.325 +b=6357057.612090616 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Wright Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.03333333333333 +lat_2=45.46666666666667 +lat_0=44.96666666666667 +lon_0=-93.88333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378443.325 +b=6357057.612090616 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Yellow Medicine Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.66666666666666 +lat_2=44.95 +lat_0=44.53333333333333 +lon_0=-95.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012192 +a=6378530.193 +b=6357144.188838657 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Minnesota"
p.Name = "NAD 1983 HARN Adj MN Yellow Medicine Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.66666666666666 +lat_2=44.95 +lat_0=44.53333333333333 +lon_0=-95.90000000000001 +x_0=152400.3048006096 +y_0=30480.06096012193 +a=6378530.193 +b=6357144.188838657 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Adams Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.36666666666667 +lon_0=-90 +k=0.999999 +x_0=147218.6944373889 +y_0=0 +a=6378376.271 +b=6356991.5851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Adams Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.36666666666667 +lon_0=-90 +k=0.999999 +x_0=147218.6944373889 +y_0=0 +a=6378376.271 +b=6356991.5851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Ashland Feet"
p.PROJ4 = "+proj=tmerc +lat_0=45.70611111111111 +lon_0=-90.62222222222222 +k=0.999997 +x_0=172821.9456438913 +y_0=0 +a=6378471.92 +b=6357087.2341403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Ashland Meters"
p.PROJ4 = "+proj=tmerc +lat_0=45.70611111111111 +lon_0=-90.62222222222222 +k=0.999997 +x_0=172821.9456438913 +y_0=0 +a=6378471.92 +b=6357087.2341403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Barron Feet"
p.PROJ4 = "+proj=tmerc +lat_0=45.13333333333333 +lon_0=-91.84999999999999 +k=0.999996 +x_0=93150 +y_0=0 +a=6378472.931 +b=6357088.2451403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Barron Meters"
p.PROJ4 = "+proj=tmerc +lat_0=45.13333333333333 +lon_0=-91.84999999999999 +k=0.999996 +x_0=93150 +y_0=0 +a=6378472.931 +b=6357088.2451403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Bayfield Feet"
p.PROJ4 = "+proj=lcc +lat_1=46.41388888888888 +lat_2=46.925 +lat_0=45.33333333333334 +lon_0=-91.15277777777779 +x_0=228600.4572009144 +y_0=0 +a=6378411.351 +b=6357026.6651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Bayfield Meters"
p.PROJ4 = "+proj=lcc +lat_1=46.41388888888888 +lat_2=46.925 +lat_0=45.33333333333334 +lon_0=-91.15277777777779 +x_0=228600.4572009144 +y_0=0 +a=6378411.351 +b=6357026.6651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Brown Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43 +lon_0=-88 +k=1.000020 +x_0=31599.99998983998 +y_0=4599.989839979679 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Brown Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43 +lon_0=-88 +k=1.000020 +x_0=31599.99998984 +y_0=4599.98983997968 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Buffalo Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.48138888888889 +lon_0=-91.79722222222222 +k=1.000000 +x_0=175260.350520701 +y_0=0 +a=6378380.991 +b=6356996.305140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Buffalo Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.48138888888889 +lon_0=-91.79722222222222 +k=1.000000 +x_0=175260.3505207011 +y_0=0 +a=6378380.991 +b=6356996.305140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Burnett Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.71388888888889 +lat_2=46.08333333333334 +lat_0=45.36388888888889 +lon_0=-92.45777777777778 +x_0=64008.12801625603 +y_0=0 +a=6378414.96 +b=6357030.2741403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Burnett Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.71388888888889 +lat_2=46.08333333333334 +lat_0=45.36388888888889 +lon_0=-92.45777777777778 +x_0=64008.12801625604 +y_0=0 +a=6378414.96 +b=6357030.2741403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Calumet Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.889509779 +y_0=0 +a=6378345.09 +b=6356960.4041403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Calumet Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.8895097791 +y_0=0 +a=6378345.09 +b=6356960.4041403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Chippewa Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.81388888888888 +lat_2=45.14166666666667 +lat_0=44.58111111111111 +lon_0=-91.29444444444444 +x_0=60045.72009144018 +y_0=0 +a=6378412.542 +b=6357027.856140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Chippewa Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.81388888888888 +lat_2=45.14166666666667 +lat_0=44.58111111111111 +lon_0=-91.29444444444444 +x_0=60045.72009144019 +y_0=0 +a=6378412.542 +b=6357027.856140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Clark Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.6 +lon_0=-90.70833333333334 +k=0.999994 +x_0=199949.1998983998 +y_0=0 +a=6378470.401 +b=6357085.7151403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Clark Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.6 +lon_0=-90.70833333333334 +k=0.999994 +x_0=199949.1998984 +y_0=0 +a=6378470.401 +b=6357085.7151403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Columbia Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.33333333333334 +lat_2=43.59166666666667 +lat_0=42.45833333333334 +lon_0=-89.39444444444445 +x_0=169164.3383286767 +y_0=0 +a=6378376.331 +b=6356991.645140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Columbia Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.33333333333334 +lat_2=43.59166666666667 +lat_0=42.45833333333334 +lon_0=-89.39444444444445 +x_0=169164.3383286767 +y_0=0 +a=6378376.331 +b=6356991.645140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Crawford Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.05833333333333 +lat_2=43.34166666666667 +lat_0=42.71666666666667 +lon_0=-90.9388888888889 +x_0=113690.6273812548 +y_0=0 +a=6378379.031 +b=6356994.345140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Crawford Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.05833333333333 +lat_2=43.34166666666667 +lat_0=42.71666666666667 +lon_0=-90.9388888888889 +x_0=113690.6273812548 +y_0=0 +a=6378379.031 +b=6356994.345140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Dane Feet"
p.PROJ4 = "+proj=lcc +lat_1=42.90833333333333 +lat_2=43.23055555555555 +lat_0=41.75 +lon_0=-89.42222222222223 +x_0=247193.2943865888 +y_0=0 +a=6378407.621 +b=6357022.935140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Dane Meters"
p.PROJ4 = "+proj=lcc +lat_1=42.90833333333333 +lat_2=43.23055555555555 +lat_0=41.75 +lon_0=-89.42222222222223 +x_0=247193.2943865888 +y_0=0 +a=6378407.621 +b=6357022.935140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Dodge Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.47222222222222 +lon_0=-88.77500000000001 +k=0.999997 +x_0=263347.7266954534 +y_0=0 +a=6378376.811 +b=6356992.1251403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Dodge Meters"
p.PROJ4 = "+proj=tmerc +lat_0=41.47222222222222 +lon_0=-88.77500000000001 +k=0.999997 +x_0=263347.7266954534 +y_0=0 +a=6378376.811 +b=6356992.1251403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Door Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.4 +lon_0=-87.27222222222223 +k=0.999991 +x_0=158801.1176022352 +y_0=0 +a=6378313.92 +b=6356929.2341403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Door Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.4 +lon_0=-87.27222222222223 +k=0.999991 +x_0=158801.1176022352 +y_0=0 +a=6378313.92 +b=6356929.2341403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Douglas Feet"
p.PROJ4 = "+proj=tmerc +lat_0=45.88333333333333 +lon_0=-91.91666666666667 +k=0.999995 +x_0=59131.31826263652 +y_0=0 +a=6378414.93 +b=6357030.2441403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Douglas Meters"
p.PROJ4 = "+proj=tmerc +lat_0=45.88333333333333 +lon_0=-91.91666666666667 +k=0.999995 +x_0=59131.31826263653 +y_0=0 +a=6378414.93 +b=6357030.2441403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Dunn Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.40833333333333 +lon_0=-91.89444444444445 +k=0.999998 +x_0=51816.10363220726 +y_0=0 +a=6378413.021 +b=6357028.3351403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Dunn Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.40833333333333 +lon_0=-91.89444444444445 +k=0.999998 +x_0=51816.10363220727 +y_0=0 +a=6378413.021 +b=6357028.3351403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI EauClaire Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.73055555555555 +lat_2=45.01388888888889 +lat_0=44.04722222222222 +lon_0=-91.28888888888889 +x_0=120091.4401828804 +y_0=0 +a=6378380.381 +b=6356995.6951403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI EauClaire Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.73055555555555 +lat_2=45.01388888888889 +lat_0=44.04722222222222 +lon_0=-91.28888888888889 +x_0=120091.4401828804 +y_0=0 +a=6378380.381 +b=6356995.6951403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Florence Feet"
p.PROJ4 = "+proj=tmerc +lat_0=45.43888888888888 +lon_0=-88.14166666666668 +k=0.999993 +x_0=133502.667005334 +y_0=0 +a=6378530.851 +b=6357146.1651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Florence Meters"
p.PROJ4 = "+proj=tmerc +lat_0=45.43888888888888 +lon_0=-88.14166666666668 +k=0.999993 +x_0=133502.667005334 +y_0=0 +a=6378530.851 +b=6357146.1651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Fond du Lac Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.889509779 +y_0=0 +a=6378345.09 +b=6356960.4041403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Fond du Lac Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.8895097791 +y_0=0 +a=6378345.09 +b=6356960.4041403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Forest Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.00555555555555 +lon_0=-88.63333333333334 +k=0.999996 +x_0=275844.5516891034 +y_0=0 +a=6378591.521 +b=6357206.8351403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Forest Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.00555555555555 +lon_0=-88.63333333333334 +k=0.999996 +x_0=275844.5516891034 +y_0=0 +a=6378591.521 +b=6357206.8351403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Grant Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.41111111111111 +lon_0=-90.8 +k=0.999997 +x_0=242316.4846329693 +y_0=0 +a=6378378.881 +b=6356994.1951403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Grant Meters"
p.PROJ4 = "+proj=tmerc +lat_0=41.41111111111111 +lon_0=-90.8 +k=0.999997 +x_0=242316.4846329693 +y_0=0 +a=6378378.881 +b=6356994.1951403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Green Feet"
p.PROJ4 = "+proj=lcc +lat_1=42.48611111111111 +lat_2=42.78888888888888 +lat_0=42.225 +lon_0=-89.83888888888889 +x_0=170078.7401574803 +y_0=0 +a=6378408.481 +b=6357023.7951403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Green Meters"
p.PROJ4 = "+proj=lcc +lat_1=42.48611111111111 +lat_2=42.78888888888888 +lat_0=42.225 +lon_0=-89.83888888888889 +x_0=170078.7401574803 +y_0=0 +a=6378408.481 +b=6357023.7951403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI GreenLake Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.66666666666666 +lat_2=43.94722222222222 +lat_0=43.09444444444445 +lon_0=-89.24166666666667 +x_0=150876.3017526035 +y_0=0 +a=6378375.601 +b=6356990.9151403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI GreenLake Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.66666666666666 +lat_2=43.94722222222222 +lat_0=43.09444444444445 +lon_0=-89.24166666666667 +x_0=150876.3017526035 +y_0=0 +a=6378375.601 +b=6356990.9151403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Iowa Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.53888888888888 +lon_0=-90.16111111111111 +k=0.999997 +x_0=113081.0261620523 +y_0=0 +a=6378408.041 +b=6357023.355140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Iowa Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.53888888888888 +lon_0=-90.16111111111111 +k=0.999997 +x_0=113081.0261620523 +y_0=0 +a=6378408.041 +b=6357023.355140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Iron Feet"
p.PROJ4 = "+proj=tmerc +lat_0=45.43333333333333 +lon_0=-90.25555555555556 +k=0.999996 +x_0=220980.4419608839 +y_0=0 +a=6378655.071000001 +b=6357270.385140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Iron Meters"
p.PROJ4 = "+proj=tmerc +lat_0=45.43333333333333 +lon_0=-90.25555555555556 +k=0.999996 +x_0=220980.4419608839 +y_0=0 +a=6378655.071000001 +b=6357270.385140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Jackson Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.16388888888888 +lat_2=44.41944444444444 +lat_0=43.79444444444444 +lon_0=-90.73888888888889 +x_0=125882.6517653035 +y_0=0 +a=6378409.151 +b=6357024.4651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Jackson Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.16388888888888 +lat_2=44.41944444444444 +lat_0=43.79444444444444 +lon_0=-90.73888888888889 +x_0=125882.6517653035 +y_0=0 +a=6378409.151 +b=6357024.4651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Jefferson Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.47222222222222 +lon_0=-88.77500000000001 +k=0.999997 +x_0=263347.7266954534 +y_0=0 +a=6378376.811 +b=6356992.1251403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Jefferson Meters"
p.PROJ4 = "+proj=tmerc +lat_0=41.47222222222222 +lon_0=-88.77500000000001 +k=0.999997 +x_0=263347.7266954534 +y_0=0 +a=6378376.811 +b=6356992.1251403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Juneau Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.36666666666667 +lon_0=-90 +k=0.999999 +x_0=147218.6944373889 +y_0=0 +a=6378376.271 +b=6356991.5851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Juneau Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.36666666666667 +lon_0=-90 +k=0.999999 +x_0=147218.6944373889 +y_0=0 +a=6378376.271 +b=6356991.5851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Kenosha Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Kenosha Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Kewaunee Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.26666666666667 +lon_0=-87.55 +k=1.000000 +x_0=79857.75971551942 +y_0=0 +a=6378285.86 +b=6356901.174140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Kewaunee Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.26666666666667 +lon_0=-87.55 +k=1.000000 +x_0=79857.75971551944 +y_0=0 +a=6378285.86 +b=6356901.174140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI LaCrosse Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.45111111111111 +lon_0=-91.31666666666666 +k=0.999994 +x_0=130454.6609093218 +y_0=0 +a=6378379.301 +b=6356994.6151403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI LaCrosse Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.45111111111111 +lon_0=-91.31666666666666 +k=0.999994 +x_0=130454.6609093218 +y_0=0 +a=6378379.301 +b=6356994.6151403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Lafayette Feet"
p.PROJ4 = "+proj=lcc +lat_1=42.48611111111111 +lat_2=42.78888888888888 +lat_0=42.225 +lon_0=-89.83888888888889 +x_0=170078.7401574803 +y_0=0 +a=6378408.481 +b=6357023.7951403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Lafayette Meters"
p.PROJ4 = "+proj=lcc +lat_1=42.48611111111111 +lat_2=42.78888888888888 +lat_0=42.225 +lon_0=-89.83888888888889 +x_0=170078.7401574803 +y_0=0 +a=6378408.481 +b=6357023.7951403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Langlade Feet"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=45.30833333333333 +lat_0=44.20694444444445 +lon_0=-89.03333333333333 +x_0=198425.1968503937 +y_0=0 +a=6378560.121 +b=6357175.435140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Langlade Meters"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=45.30833333333333 +lat_0=44.20694444444445 +lon_0=-89.03333333333333 +x_0=198425.1968503937 +y_0=0 +a=6378560.121 +b=6357175.435140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Lincoln Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.84444444444445 +lon_0=-89.73333333333333 +k=0.999998 +x_0=116129.0322580645 +y_0=0 +a=6378531.821000001 +b=6357147.135140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Lincoln Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.84444444444445 +lon_0=-89.73333333333333 +k=0.999998 +x_0=116129.0322580645 +y_0=0 +a=6378531.821000001 +b=6357147.135140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Manitowoc Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.26666666666667 +lon_0=-87.55 +k=1.000000 +x_0=79857.75971551942 +y_0=0 +a=6378285.86 +b=6356901.174140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Manitowoc Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.26666666666667 +lon_0=-87.55 +k=1.000000 +x_0=79857.75971551944 +y_0=0 +a=6378285.86 +b=6356901.174140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Marathon Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.74527777777778 +lat_2=45.05638888888888 +lat_0=44.40555555555555 +lon_0=-89.77 +x_0=74676.1493522987 +y_0=0 +a=6378500.6 +b=6357115.9141403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Marathon Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.74527777777778 +lat_2=45.05638888888888 +lat_0=44.40555555555555 +lon_0=-89.77 +x_0=74676.14935229872 +y_0=0 +a=6378500.6 +b=6357115.9141403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Marinette Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.69166666666666 +lon_0=-87.71111111111111 +k=0.999986 +x_0=238658.8773177546 +y_0=0 +a=6378376.041 +b=6356991.355140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Marinette Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.69166666666666 +lon_0=-87.71111111111111 +k=0.999986 +x_0=238658.8773177547 +y_0=0 +a=6378376.041 +b=6356991.355140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Marquette Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.66666666666666 +lat_2=43.94722222222222 +lat_0=43.09444444444445 +lon_0=-89.24166666666667 +x_0=150876.3017526035 +y_0=0 +a=6378375.601 +b=6356990.9151403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Marquette Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.66666666666666 +lat_2=43.94722222222222 +lat_0=43.09444444444445 +lon_0=-89.24166666666667 +x_0=150876.3017526035 +y_0=0 +a=6378375.601 +b=6356990.9151403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Menominee Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.71666666666667 +lon_0=-88.41666666666667 +k=0.999994 +x_0=105461.0109220218 +y_0=0 +a=6378406.601 +b=6357021.9151403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Menominee Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.71666666666667 +lon_0=-88.41666666666667 +k=0.999994 +x_0=105461.0109220219 +y_0=0 +a=6378406.601 +b=6357021.9151403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Milwaukee Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Milwaukee Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Monroe Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.83888888888889 +lat_2=44.16111111111111 +lat_0=42.90277777777778 +lon_0=-90.64166666666668 +x_0=204521.2090424181 +y_0=0 +a=6378438.991 +b=6357054.305140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Monroe Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.83888888888889 +lat_2=44.16111111111111 +lat_0=42.90277777777778 +lon_0=-90.64166666666668 +x_0=204521.2090424181 +y_0=0 +a=6378438.991 +b=6357054.305140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Oconto Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.39722222222222 +lon_0=-87.90833333333335 +k=0.999991 +x_0=182880.3657607315 +y_0=0 +a=6378345.42 +b=6356960.7341403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Oconto Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.39722222222222 +lon_0=-87.90833333333335 +k=0.999991 +x_0=182880.3657607315 +y_0=0 +a=6378345.42 +b=6356960.7341403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Oneida Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=45.84166666666667 +lat_0=45.18611111111111 +lon_0=-89.54444444444444 +x_0=70104.14020828041 +y_0=0 +a=6378593.86 +b=6357209.174140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Oneida Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=45.84166666666667 +lat_0=45.18611111111111 +lon_0=-89.54444444444444 +x_0=70104.14020828043 +y_0=0 +a=6378593.86 +b=6357209.174140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Outagamie Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.889509779 +y_0=0 +a=6378345.09 +b=6356960.4041403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Outagamie Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.8895097791 +y_0=0 +a=6378345.09 +b=6356960.4041403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Ozaukee Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Ozaukee Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Pepin Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.52222222222222 +lat_2=44.75 +lat_0=43.86194444444445 +lon_0=-92.22777777777777 +x_0=167640.3352806706 +y_0=0 +a=6378381.271 +b=6356996.5851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Pepin Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.52222222222222 +lat_2=44.75 +lat_0=43.86194444444445 +lon_0=-92.22777777777777 +x_0=167640.3352806706 +y_0=0 +a=6378381.271 +b=6356996.5851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Pierce Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.52222222222222 +lat_2=44.75 +lat_0=43.86194444444445 +lon_0=-92.22777777777777 +x_0=167640.3352806706 +y_0=0 +a=6378381.271 +b=6356996.5851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Pierce Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.52222222222222 +lat_2=44.75 +lat_0=43.86194444444445 +lon_0=-92.22777777777777 +x_0=167640.3352806706 +y_0=0 +a=6378381.271 +b=6356996.5851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Polk Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.66111111111111 +lon_0=-92.63333333333334 +k=1.000000 +x_0=141732.2834645669 +y_0=0 +a=6378413.671 +b=6357028.9851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Polk Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.66111111111111 +lon_0=-92.63333333333334 +k=1.000000 +x_0=141732.2834645669 +y_0=0 +a=6378413.671 +b=6357028.9851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Portage Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=44.65 +lat_0=43.96666666666667 +lon_0=-89.5 +x_0=56388.11277622555 +y_0=0 +a=6378344.377 +b=6356959.691139228 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Portage Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=44.65 +lat_0=43.96666666666667 +lon_0=-89.5 +x_0=56388.11277622556 +y_0=0 +a=6378344.377 +b=6356959.691139228 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Price Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.55555555555555 +lon_0=-90.48888888888889 +k=0.999998 +x_0=227990.8559817119 +y_0=0 +a=6378563.891 +b=6357179.2051403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Price Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.55555555555555 +lon_0=-90.48888888888889 +k=0.999998 +x_0=227990.855981712 +y_0=0 +a=6378563.891 +b=6357179.2051403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Racine Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Racine Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.21666666666667 +lon_0=-87.89444444444445 +k=0.999998 +x_0=185928.3718567437 +y_0=0 +a=6378315.7 +b=6356931.014140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Richland Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.14166666666667 +lat_2=43.50277777777778 +lat_0=42.11388888888889 +lon_0=-90.43055555555556 +x_0=202387.6047752095 +y_0=0 +a=6378408.091 +b=6357023.4051403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Richland Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.14166666666667 +lat_2=43.50277777777778 +lat_0=42.11388888888889 +lon_0=-90.43055555555556 +x_0=202387.6047752096 +y_0=0 +a=6378408.091 +b=6357023.4051403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Rock Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.94444444444444 +lon_0=-89.07222222222222 +k=0.999996 +x_0=146304.2926085852 +y_0=0 +a=6378377.671 +b=6356992.9851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Rock Meters"
p.PROJ4 = "+proj=tmerc +lat_0=41.94444444444444 +lon_0=-89.07222222222222 +k=0.999996 +x_0=146304.2926085852 +y_0=0 +a=6378377.671 +b=6356992.9851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Rusk Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.91944444444444 +lon_0=-91.06666666666666 +k=0.999997 +x_0=250546.1010922022 +y_0=0 +a=6378472.751 +b=6357088.0651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Rusk Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.91944444444444 +lon_0=-91.06666666666666 +k=0.999997 +x_0=250546.1010922022 +y_0=0 +a=6378472.751 +b=6357088.0651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Sauk Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.81944444444445 +lon_0=-89.90000000000001 +k=0.999995 +x_0=185623.5712471425 +y_0=0 +a=6378407.281 +b=6357022.595140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Sauk Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.81944444444445 +lon_0=-89.90000000000001 +k=0.999995 +x_0=185623.5712471425 +y_0=0 +a=6378407.281 +b=6357022.595140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Sawyer Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.71944444444445 +lat_2=46.08055555555556 +lat_0=44.81388888888888 +lon_0=-91.11666666666666 +x_0=216713.2334264669 +y_0=0 +a=6378534.451 +b=6357149.765140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Sawyer Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.71944444444445 +lat_2=46.08055555555556 +lat_0=44.81388888888888 +lon_0=-91.11666666666666 +x_0=216713.2334264669 +y_0=0 +a=6378534.451 +b=6357149.765140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Shawano Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.03611111111111 +lon_0=-88.60555555555555 +k=0.999990 +x_0=262433.3248666497 +y_0=0 +a=6378406.051 +b=6357021.3651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Shawano Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.03611111111111 +lon_0=-88.60555555555555 +k=0.999990 +x_0=262433.3248666498 +y_0=0 +a=6378406.051 +b=6357021.3651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Sheboygan Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.26666666666667 +lon_0=-87.55 +k=1.000000 +x_0=79857.75971551942 +y_0=0 +a=6378285.86 +b=6356901.174140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Sheboygan Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.26666666666667 +lon_0=-87.55 +k=1.000000 +x_0=79857.75971551944 +y_0=0 +a=6378285.86 +b=6356901.174140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI St Croix Feet"
p.PROJ4 = "+proj=tmerc +lat_0=44.03611111111111 +lon_0=-92.63333333333334 +k=0.999995 +x_0=165506.731013462 +y_0=0 +a=6378412.511 +b=6357027.8251403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI St Croix Meters"
p.PROJ4 = "+proj=tmerc +lat_0=44.03611111111111 +lon_0=-92.63333333333334 +k=0.999995 +x_0=165506.731013462 +y_0=0 +a=6378412.511 +b=6357027.8251403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Taylor Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.05555555555555 +lat_2=45.3 +lat_0=44.20833333333334 +lon_0=-90.48333333333333 +x_0=187147.5742951486 +y_0=0 +a=6378532.921 +b=6357148.2351403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Taylor Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.05555555555555 +lat_2=45.3 +lat_0=44.20833333333334 +lon_0=-90.48333333333333 +x_0=187147.5742951486 +y_0=0 +a=6378532.921 +b=6357148.2351403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Trempealeau Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.16111111111111 +lon_0=-91.36666666666666 +k=0.999998 +x_0=256946.9138938278 +y_0=0 +a=6378380.091 +b=6356995.4051403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Trempealeau Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.16111111111111 +lon_0=-91.36666666666666 +k=0.999998 +x_0=256946.9138938278 +y_0=0 +a=6378380.091 +b=6356995.4051403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Vernon Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.46666666666667 +lat_2=43.68333333333333 +lat_0=43.14722222222222 +lon_0=-90.78333333333333 +x_0=222504.44500889 +y_0=0 +a=6378408.941 +b=6357024.2551403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Vernon Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.46666666666667 +lat_2=43.68333333333333 +lat_0=43.14722222222222 +lon_0=-90.78333333333333 +x_0=222504.44500889 +y_0=0 +a=6378408.941 +b=6357024.2551403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Vilas Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.93055555555555 +lat_2=46.225 +lat_0=45.625 +lon_0=-89.48888888888889 +x_0=134417.0688341377 +y_0=0 +a=6378624.171 +b=6357239.4851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Vilas Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.93055555555555 +lat_2=46.225 +lat_0=45.625 +lon_0=-89.48888888888889 +x_0=134417.0688341377 +y_0=0 +a=6378624.171 +b=6357239.4851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Walworth Feet"
p.PROJ4 = "+proj=lcc +lat_1=42.58888888888889 +lat_2=42.75 +lat_0=41.66944444444444 +lon_0=-88.54166666666667 +x_0=232562.8651257302 +y_0=0 +a=6378377.411 +b=6356992.725140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Walworth Meters"
p.PROJ4 = "+proj=lcc +lat_1=42.58888888888889 +lat_2=42.75 +lat_0=41.66944444444444 +lon_0=-88.54166666666667 +x_0=232562.8651257303 +y_0=0 +a=6378377.411 +b=6356992.725140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Washburn Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.77222222222222 +lat_2=46.15 +lat_0=44.26666666666667 +lon_0=-91.78333333333333 +x_0=234086.8681737363 +y_0=0 +a=6378474.591 +b=6357089.9051403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Washburn Meters"
p.PROJ4 = "+proj=lcc +lat_1=45.77222222222222 +lat_2=46.15 +lat_0=44.26666666666667 +lon_0=-91.78333333333333 +x_0=234086.8681737364 +y_0=0 +a=6378474.591 +b=6357089.9051403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Washington Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.91805555555555 +lon_0=-88.06388888888888 +k=0.999995 +x_0=120091.4401828804 +y_0=0 +a=6378407.141 +b=6357022.4551403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Washington Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.91805555555555 +lon_0=-88.06388888888888 +k=0.999995 +x_0=120091.4401828804 +y_0=0 +a=6378407.141 +b=6357022.4551403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Waukesha Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.56944444444445 +lon_0=-88.22499999999999 +k=0.999997 +x_0=208788.4175768351 +y_0=0 +a=6378376.871 +b=6356992.185140301 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Waukesha Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.56944444444445 +lon_0=-88.22499999999999 +k=0.999997 +x_0=208788.4175768352 +y_0=0 +a=6378376.871 +b=6356992.185140301 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Waupaca Feet"
p.PROJ4 = "+proj=tmerc +lat_0=43.42027777777778 +lon_0=-88.81666666666666 +k=0.999996 +x_0=185013.9700279401 +y_0=0 +a=6378375.251 +b=6356990.5651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Waupaca Meters"
p.PROJ4 = "+proj=tmerc +lat_0=43.42027777777778 +lon_0=-88.81666666666666 +k=0.999996 +x_0=185013.9700279401 +y_0=0 +a=6378375.251 +b=6356990.5651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Waushara Feet"
p.PROJ4 = "+proj=lcc +lat_1=43.975 +lat_2=44.25277777777778 +lat_0=43.70833333333334 +lon_0=-89.24166666666667 +x_0=120091.4401828804 +y_0=0 +a=6378405.971 +b=6357021.2851403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Waushara Meters"
p.PROJ4 = "+proj=lcc +lat_1=43.975 +lat_2=44.25277777777778 +lat_0=43.70833333333334 +lon_0=-89.24166666666667 +x_0=120091.4401828804 +y_0=0 +a=6378405.971 +b=6357021.2851403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Winnebago Feet"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.889509779 +y_0=0 +a=6378345.09 +b=6356960.4041403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Winnebago Meters"
p.PROJ4 = "+proj=tmerc +lat_0=42.71944444444445 +lon_0=-88.5 +k=0.999996 +x_0=244754.8895097791 +y_0=0 +a=6378345.09 +b=6356960.4041403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Wood Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.18055555555555 +lat_2=44.54444444444444 +lat_0=43.15138888888889 +lon_0=-90 +x_0=208483.6169672339 +y_0=0 +a=6378437.651 +b=6357052.9651403 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "County Systems - Wisconsin"
p.Name = "NAD 1983 HARN Adj WI Wood Meters"
p.PROJ4 = "+proj=lcc +lat_1=44.18055555555555 +lat_2=44.54444444444444 +lat_0=43.15138888888889 +lon_0=-90 +x_0=208483.616967234 +y_0=0 +a=6378437.651 +b=6357052.9651403 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 102E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 105E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 108E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 111E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 114E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 117E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 120E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 123E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 126E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 129E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 132E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 135E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 75E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 78E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 81E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 84E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 87E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 90E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 93E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 96E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK CM 99E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 25"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=25500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 26"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=26500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=27500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=28500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 29"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=29500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=30500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=31500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 32"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=32500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 33"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=33500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 34"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=34500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 35"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=35500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 36"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=36500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 37"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=37500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 38"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=38500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 39"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=39500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 40"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=40500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 41"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=41500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 42"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=42500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 43"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=43500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 44"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=44500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 3 Degree GK Zone 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=45500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=13500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 13N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=14500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 14N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=15500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 15N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=16500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 16N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=17500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 17N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=18500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 18N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=19500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 19N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 20"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=20500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 20N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 21"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=21500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 21N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 22"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=22500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 22N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 23"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=23500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Beijing 1954"
p.Name = "Beijing 1954 GK Zone 23N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "Albanian 1987 GK Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=10500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=11500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=1.000000 +x_0=12500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=13500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=1.000000 +x_0=14500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=15500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "ED 1950 3 Degree GK Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=9500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "Hanoi 1972 GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=18500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "Hanoi 1972 GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=19500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "Pulkovo 1942 Adj 1983 3 Degree GK Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "Pulkovo 1942 Adj 1983 3 Degree GK Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "Pulkovo 1942 Adj 1983 3 Degree GK Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "South Yemen GK Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=8500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Other GCS"
p.Name = "South Yemen GK Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=9500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 102E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 105E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 108E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 111E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 114E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 117E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 120E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 123E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 126E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 129E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 132E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 135E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 138E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=138 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 141E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 144E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=144 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 147E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 150E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=150 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 153E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 156E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=156 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 159E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 162E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=162 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 165E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 168E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=168 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 168W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-168 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 171E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 171W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 174E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=174 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 174W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-174 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 177E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 177W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 180E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=180 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 21E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 24E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 27E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 30E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 33E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 36E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 39E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 42E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 45E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 48E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 51E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 54E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=54 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 57E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 60E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=60 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 63E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 66E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=66 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 69E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 72E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=72 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 75E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 78E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 81E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 84E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 87E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 90E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 93E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 96E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK CM 99E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=10500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=11500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=1.000000 +x_0=12500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=13500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=1.000000 +x_0=14500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=15500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48 +k=1.000000 +x_0=16500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=17500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=54 +k=1.000000 +x_0=18500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=19500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 20"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=60 +k=1.000000 +x_0=20500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 21"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=21500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 22"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=66 +k=1.000000 +x_0=22500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 23"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=23500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 24"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=72 +k=1.000000 +x_0=24500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 25"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=25500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 26"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=26500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=27500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=28500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 29"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=29500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=30500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=31500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 32"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=32500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 33"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=33500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 34"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=34500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 35"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=35500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 36"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=36500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 37"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=37500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 38"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=38500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 39"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=39500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 40"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=40500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 41"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=41500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 42"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=42500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 43"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=43500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 44"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=44500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=45500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 46"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=138 +k=1.000000 +x_0=46500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 47"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=47500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 48"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=144 +k=1.000000 +x_0=48500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 49"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=49500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 50"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=150 +k=1.000000 +x_0=50500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 51"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=51500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 52"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=156 +k=1.000000 +x_0=52500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 53"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=53500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 54"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=162 +k=1.000000 +x_0=54500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 55"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=55500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 56"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=168 +k=1.000000 +x_0=56500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 57"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=57500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 58"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=174 +k=1.000000 +x_0=58500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 59"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=59500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 60"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=180 +k=1.000000 +x_0=60500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 61"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=61500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 62"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-174 +k=1.000000 +x_0=62500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 63"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=63500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 64"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-168 +k=1.000000 +x_0=64500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=7500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=8500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 3 Degree GK Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=9500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=10500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 10N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=11500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 11N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=12500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 12N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=13500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 13N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=14500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 14N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=15500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 15N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=16500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 16N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=17500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 17N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=18500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 18N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=19500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 19N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 20"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=20500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 20N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 21"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=21500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 21N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 22"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=22500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 22N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 23"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=23500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 23N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 24"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=24500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 24N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 25"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=25500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 25N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 26"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=26500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 26N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=27500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 27N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=28500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 28N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 29"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=29500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 29N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 2N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=30500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 30N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=31500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 31N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 32"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=32500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 32N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 3N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 4N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 5N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=6500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 6N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=7500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 7N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=8500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 8N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=9500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1942"
p.Name = "Pulkovo 1942 GK Zone 9N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 102E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 105E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 108E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 111E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 114E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 117E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 120E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 123E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 126E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 129E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 132E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 135E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 138E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=138 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 141E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 144E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=144 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 147E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 150E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=150 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 153E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 156E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=156 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 159E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 162E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=162 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 165E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 168E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=168 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 168W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-168 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 171E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 171W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 174E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=174 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 174W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-174 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 177E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 177W"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 180E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=180 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 21E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 24E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 27E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 30E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 33E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 36E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 39E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 42E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 45E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 48E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 51E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 54E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=54 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 57E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 60E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=60 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 63E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 66E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=66 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 69E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 72E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=72 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 75E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 78E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 81E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 84E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 87E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 90E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 93E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 96E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK CM 99E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=10500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=11500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=1.000000 +x_0=12500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=13500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=1.000000 +x_0=14500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=15500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48 +k=1.000000 +x_0=16500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=17500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=54 +k=1.000000 +x_0=18500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=19500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 20"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=60 +k=1.000000 +x_0=20500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 21"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=21500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 22"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=66 +k=1.000000 +x_0=22500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 23"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=23500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 24"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=72 +k=1.000000 +x_0=24500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 25"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=25500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 26"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=26500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=27500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=28500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 29"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=29500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=30500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=31500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 32"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=32500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 33"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=33500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 34"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=34500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 35"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=35500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 36"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=36500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 37"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=37500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 38"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=38500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 39"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=39500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 40"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=40500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 41"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=41500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 42"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=42500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 43"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=43500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 44"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=44500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=45500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 46"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=138 +k=1.000000 +x_0=46500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 47"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=47500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 48"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=144 +k=1.000000 +x_0=48500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 49"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=49500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 50"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=150 +k=1.000000 +x_0=50500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 51"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=51500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 52"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=156 +k=1.000000 +x_0=52500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 53"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=53500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 54"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=162 +k=1.000000 +x_0=54500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 55"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=55500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 56"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=168 +k=1.000000 +x_0=56500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 57"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=57500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 58"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=174 +k=1.000000 +x_0=58500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 59"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=59500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 60"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=180 +k=1.000000 +x_0=60500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 61"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=61500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 62"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-174 +k=1.000000 +x_0=62500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 63"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=63500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 64"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-168 +k=1.000000 +x_0=64500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=7500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=8500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 3 Degree GK Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=9500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=10500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 10N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=57 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=11500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 11N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=63 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=12500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 12N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=69 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=13500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 13N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=14500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 14N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=15500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 15N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=16500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 16N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=17500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 17N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=18500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 18N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=19500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 19N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 20"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=20500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 20N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 21"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=21500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 21N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 22"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=22500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 22N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 23"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=23500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 23N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 24"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=24500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 24N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 25"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=25500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 25N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 26"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=26500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 26N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=27500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 27N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=159 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=28500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 28N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=165 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 29"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=29500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 29N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 2N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=30500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 30N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=31500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 31N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-177 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 32"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=32500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 32N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-171 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 3N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 4N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 5N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=6500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 6N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=7500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 7N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=8500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 8N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=9500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Pulkovo 1995"
p.Name = "Pulkovo 1995 GK Zone 9N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 102E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 105E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 108E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 111E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 114E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 117E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 120E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 123E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 126E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 129E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 132E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 135E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 75E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 78E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 81E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 84E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 87E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 90E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 93E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 96E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK CM 99E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 25"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=25500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 26"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=78 +k=1.000000 +x_0=26500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=27500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=84 +k=1.000000 +x_0=28500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 29"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=29500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=90 +k=1.000000 +x_0=30500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=31500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 32"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=96 +k=1.000000 +x_0=32500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 33"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=33500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 34"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=102 +k=1.000000 +x_0=34500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 35"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=35500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 36"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=108 +k=1.000000 +x_0=36500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 37"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=37500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 38"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=114 +k=1.000000 +x_0=38500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 39"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=39500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 40"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=120 +k=1.000000 +x_0=40500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 41"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=41500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 42"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=126 +k=1.000000 +x_0=42500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 43"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=43500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 44"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=1.000000 +x_0=44500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 3 Degree GK Zone 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=45500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 105E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 111E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 117E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 123E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 129E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 135E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 75E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 81E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 87E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 93E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK CM 99E"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=75 +k=1.000000 +x_0=13500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=81 +k=1.000000 +x_0=14500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=87 +k=1.000000 +x_0=15500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=93 +k=1.000000 +x_0=16500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=99 +k=1.000000 +x_0=17500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=105 +k=1.000000 +x_0=18500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=111 +k=1.000000 +x_0=19500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 20"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=1.000000 +x_0=20500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 21"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=1.000000 +x_0=21500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 22"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=129 +k=1.000000 +x_0=22500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Gauss Kruger - Xian 1980"
p.Name = "Xian 1980 GK Zone 23"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=135 +k=1.000000 +x_0=23500000 +y_0=0 +a=6378140 +b=6356755.288157528 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ACT Grid AGC Zone"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=149.0092948333333 +k=1.000086 +x_0=200000 +y_0=4510193.4939 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 48"
p.PROJ4 = "+proj=utm +zone=48 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 49"
p.PROJ4 = "+proj=utm +zone=49 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 50"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 51"
p.PROJ4 = "+proj=utm +zone=51 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 52"
p.PROJ4 = "+proj=utm +zone=52 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 53"
p.PROJ4 = "+proj=utm +zone=53 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 54"
p.PROJ4 = "+proj=utm +zone=54 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 55"
p.PROJ4 = "+proj=utm +zone=55 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 56"
p.PROJ4 = "+proj=utm +zone=56 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 57"
p.PROJ4 = "+proj=utm +zone=57 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 AMG Zone 58"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 54 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=141 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 54 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=143 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 55 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=145 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 55 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=147 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 55 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=149 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 56 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=151 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 56 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=153 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 ISG 56 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=155 +k=0.999940 +x_0=300000 +y_0=5000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1966 VICGRID"
p.PROJ4 = "+proj=lcc +lat_1=-36 +lat_2=-38 +lat_0=-37 +lon_0=145 +x_0=2500000 +y_0=4500000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 48"
p.PROJ4 = "+proj=utm +zone=48 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 49"
p.PROJ4 = "+proj=utm +zone=49 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 50"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 51"
p.PROJ4 = "+proj=utm +zone=51 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 52"
p.PROJ4 = "+proj=utm +zone=52 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 53"
p.PROJ4 = "+proj=utm +zone=53 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 54"
p.PROJ4 = "+proj=utm +zone=54 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 55"
p.PROJ4 = "+proj=utm +zone=55 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 56"
p.PROJ4 = "+proj=utm +zone=56 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 57"
p.PROJ4 = "+proj=utm +zone=57 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "AGD 1984 AMG Zone 58"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 48"
p.PROJ4 = "+proj=utm +zone=48 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 49"
p.PROJ4 = "+proj=utm +zone=49 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 50"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 51"
p.PROJ4 = "+proj=utm +zone=51 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 52"
p.PROJ4 = "+proj=utm +zone=52 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 53"
p.PROJ4 = "+proj=utm +zone=53 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 54"
p.PROJ4 = "+proj=utm +zone=54 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 55"
p.PROJ4 = "+proj=utm +zone=55 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 56"
p.PROJ4 = "+proj=utm +zone=56 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 57"
p.PROJ4 = "+proj=utm +zone=57 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 MGA Zone 58"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 South Australia Lambert"
p.PROJ4 = "+proj=lcc +lat_1=-28 +lat_2=-36 +lat_0=-32 +lon_0=135 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Australia"
p.Name = "GDA 1994 VICGRID94"
p.PROJ4 = "+proj=lcc +lat_1=-36 +lat_2=-38 +lat_0=-37 +lon_0=145 +x_0=2500000 +y_0=2500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "ATS 1977 MTM 4 Nova Scotia"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-61.5 +k=0.999900 +x_0=4500000 +y_0=0 +a=6378135 +b=6356750.304921594 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "ATS 1977 MTM 5 Nova Scotia"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-64.5 +k=0.999900 +x_0=5500000 +y_0=0 +a=6378135 +b=6356750.304921594 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "ATS 1977 New Brunswick Stereographic"
p.PROJ4 = "+a=6378135 +b=6356750.304921594 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 10TM AEP Forest"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-115 +k=0.999200 +x_0=500000 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 10TM AEP Resource"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-115 +k=0.999200 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 3TM 111"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-111 +k=0.999900 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 3TM 114"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-114 +k=0.999900 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 3TM 117"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-117 +k=0.999900 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 3TM 120"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-120 +k=0.999900 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 10 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-79.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 2 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-55.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 3 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-58.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 4 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-61.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 5 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-64.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 6 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-67.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 7 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-70.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 8 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-73.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 MTM 9 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-76.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 Quebec Lambert"
p.PROJ4 = "+proj=lcc +lat_1=46 +lat_2=60 +lat_0=44 +lon_0=-68.5 +x_0=0 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 CGQ77 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-79.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-82.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-81 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-84 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-87 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-90 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-93 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-96 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-73.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 MTM 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-76.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 UTM Zone 15N"
p.PROJ4 = "+proj=utm +zone=15 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 UTM Zone 16N"
p.PROJ4 = "+proj=utm +zone=16 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 DEF 1976 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 MTM 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-53 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 MTM 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-56 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 MTM 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-58.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 MTM 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-61.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 MTM 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-64.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 MTM 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-67.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1927 Quebec Lambert"
p.PROJ4 = "+proj=lcc +lat_1=46 +lat_2=60 +lat_0=44 +lon_0=-68.5 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 10TM AEP Forest"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-115 +k=0.999200 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 10TM AEP Resource"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-115 +k=0.999200 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 3TM 111"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-111 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 3TM 114"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-114 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 3TM 117"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-117 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 3TM 120"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-120 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 BC Environment Albers"
p.PROJ4 = "+proj=aea +lat_1=50 +lat_2=58.5 +lat_0=45 +lon_0=-126 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-79.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 2 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-55.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-58.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-61.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-64.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-67.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-70.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-73.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 MTM 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-76.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 New Brunswick Stereographic"
p.PROJ4 = "+ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 Prince Edward Island"
p.PROJ4 = "+ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 11N"
p.PROJ4 = "+proj=utm +zone=11 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 12N"
p.PROJ4 = "+proj=utm +zone=12 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 13N"
p.PROJ4 = "+proj=utm +zone=13 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 CSRS98 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-53 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-79.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-82.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-81 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-84 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-87 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-90 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 16"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-93 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 17"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-96 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 2 SCoPQ"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-55.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-56 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-58.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-61.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-64.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-67.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-70.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-73.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 MTM 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-76.5 +k=0.999900 +x_0=304800 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "NAD 1983 Quebec Lambert"
p.PROJ4 = "+proj=lcc +lat_1=46 +lat_2=60 +lat_0=44 +lon_0=-68.5 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Canada"
p.Name = "Prince Edward Island Stereographic"
p.PROJ4 = "+a=6378135 +b=6356750.304921594 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1880 India Zone 0"
p.PROJ4 = "+proj=lcc +lat_1=39.5 +lat_0=39.5 +lon_0=68 +k_0=0.99846154 +x_0=2153865.73916853 +y_0=2368292.194628102 +a=6377299.36 +b=6356098.35162804 +to_meter=0.9143985307444408 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1880 India Zone I"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_0=32.5 +lon_0=68 +k_0=0.99878641 +x_0=2743195.592233322 +y_0=914398.5307444407 +a=6377299.36 +b=6356098.35162804 +to_meter=0.9143985307444408 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1880 India Zone IIa"
p.PROJ4 = "+proj=lcc +lat_1=26 +lat_0=26 +lon_0=74 +k_0=0.99878641 +x_0=2743195.592233322 +y_0=914398.5307444407 +a=6377299.36 +b=6356098.35162804 +to_meter=0.9143985307444408 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1880 India Zone IIb"
p.PROJ4 = "+proj=lcc +lat_1=26 +lat_0=26 +lon_0=90 +k_0=0.99878641 +x_0=2743195.592233322 +y_0=914398.5307444407 +a=6377299.36 +b=6356098.35162804 +to_meter=0.9143985307444408 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1880 India Zone III"
p.PROJ4 = "+proj=lcc +lat_1=19 +lat_0=19 +lon_0=80 +k_0=0.99878641 +x_0=2743195.592233322 +y_0=914398.5307444407 +a=6377299.36 +b=6356098.35162804 +to_meter=0.9143985307444408 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1880 India Zone IV"
p.PROJ4 = "+proj=lcc +lat_1=12 +lat_0=12 +lon_0=80 +k_0=0.99878641 +x_0=2743195.592233322 +y_0=914398.5307444407 +a=6377299.36 +b=6356098.35162804 +to_meter=0.9143985307444408 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1937 India Zone IIb"
p.PROJ4 = "+proj=lcc +lat_1=26 +lat_0=26 +lon_0=90 +k_0=0.99878641 +x_0=2743195.5 +y_0=914398.5 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1937 UTM Zone 45N"
p.PROJ4 = "+proj=utm +zone=45 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1937 UTM Zone 46N"
p.PROJ4 = "+proj=utm +zone=46 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1962 India Zone I"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_0=32.5 +lon_0=68 +k_0=0.99878641 +x_0=2743196.4 +y_0=914398.8000000001 +a=6377301.243 +b=6356100.230165384 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1962 India Zone IIa"
p.PROJ4 = "+proj=lcc +lat_1=26 +lat_0=26 +lon_0=74 +k_0=0.99878641 +x_0=2743196.4 +y_0=914398.8000000001 +a=6377301.243 +b=6356100.230165384 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1962 UTM Zone 41N"
p.PROJ4 = "+proj=utm +zone=41 +a=6377301.243 +b=6356100.230165384 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1962 UTM Zone 42N"
p.PROJ4 = "+proj=utm +zone=42 +a=6377301.243 +b=6356100.230165384 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1962 UTM Zone 43N"
p.PROJ4 = "+proj=utm +zone=43 +a=6377301.243 +b=6356100.230165384 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 India Zone I"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_0=32.5 +lon_0=68 +k_0=0.99878641 +x_0=2743185.69 +y_0=914395.23 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 India Zone IIa"
p.PROJ4 = "+proj=lcc +lat_1=26 +lat_0=26 +lon_0=74 +k_0=0.99878641 +x_0=2743185.69 +y_0=914395.23 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 India Zone IIb"
p.PROJ4 = "+proj=lcc +lat_1=26 +lat_0=26 +lon_0=90 +k_0=0.99878641 +x_0=2743185.69 +y_0=914395.23 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 India Zone III"
p.PROJ4 = "+proj=lcc +lat_1=19 +lat_0=19 +lon_0=80 +k_0=0.99878641 +x_0=2743185.69 +y_0=914395.23 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 India Zone IV"
p.PROJ4 = "+proj=lcc +lat_1=12 +lat_0=12 +lon_0=80 +k_0=0.99878641 +x_0=2743185.69 +y_0=914395.23 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 UTM Zone 42N"
p.PROJ4 = "+proj=utm +zone=42 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 UTM Zone 43N"
p.PROJ4 = "+proj=utm +zone=43 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 UTM Zone 44N"
p.PROJ4 = "+proj=utm +zone=44 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 UTM Zone 45N"
p.PROJ4 = "+proj=utm +zone=45 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 UTM Zone 46N"
p.PROJ4 = "+proj=utm +zone=46 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Indian subcontinent"
p.Name = "Kalianpur 1975 UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +a=6377299.151 +b=6356098.145120132 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=33 +lon_0=129.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=140.8333333333333 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=44 +lon_0=140.25 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=44 +lon_0=142.25 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=44 +lon_0=144.25 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=142 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=127.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=124 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=131 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=20 +lon_0=136 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=154 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=33 +lon_0=131 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=132.1666666666667 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=33 +lon_0=133.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=134.3333333333333 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=136 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=137.1666666666667 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=138.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "Japan Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=139.8333333333333 +k=0.999900 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=33 +lon_0=129.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 10"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=140.8333333333333 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 11"
p.PROJ4 = "+proj=tmerc +lat_0=44 +lon_0=140.25 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 12"
p.PROJ4 = "+proj=tmerc +lat_0=44 +lon_0=142.25 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 13"
p.PROJ4 = "+proj=tmerc +lat_0=44 +lon_0=144.25 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 14"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=142 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 15"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=127.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 16"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=124 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 17"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=131 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 18"
p.PROJ4 = "+proj=tmerc +lat_0=20 +lon_0=136 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 19"
p.PROJ4 = "+proj=tmerc +lat_0=26 +lon_0=154 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=33 +lon_0=131 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=132.1666666666667 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=33 +lon_0=133.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=134.3333333333333 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=136 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=137.1666666666667 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=138.5 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Japan"
p.Name = "JGD 2000 Japan Zone 9"
p.PROJ4 = "+proj=tmerc +lat_0=36 +lon_0=139.8333333333333 +k=0.999900 +x_0=0 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "Chatham Islands 1979 Map Grid"
p.PROJ4 = "+proj=tmerc +lat_0=-44 +lon_0=-176.5 +k=0.999600 +x_0=350000 +y_0=650000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "New Zealand Map Grid"
p.PROJ4 = "+proj=nzmg +lat_0=-41 +lon_0=173 +x_0=2510000 +y_0=6023150 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "New Zealand North Island"
p.PROJ4 = "+proj=tmerc +lat_0=-39 +lon_0=175.5 +k=1.000000 +x_0=274319.5243848086 +y_0=365759.3658464114 +ellps=intl +to_meter=0.9143984146160287 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "New Zealand South Island"
p.PROJ4 = "+proj=tmerc +lat_0=-44 +lon_0=171.5 +k=1.000000 +x_0=457199.2073080143 +y_0=457199.2073080143 +ellps=intl +to_meter=0.9143984146160287 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Amuri Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-42.68911658333333 +lon_0=173.0101333888889 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Bay of Plenty Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-37.76124980555556 +lon_0=176.46619725 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Bluff Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-46.60000961111111 +lon_0=168.342872 +k=1.000000 +x_0=300002.66 +y_0=699999.58 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Buller Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.81080286111111 +lon_0=171.5812600555556 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Collingwood Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-40.71475905555556 +lon_0=172.6720465 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Gawler Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.74871155555556 +lon_0=171.3607484722222 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Grey Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-42.33369427777778 +lon_0=171.5497713055556 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Hawkes Bay Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-39.65092930555556 +lon_0=176.6736805277778 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Hokitika Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-42.88632236111111 +lon_0=170.9799935 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Jacksons Bay Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.97780288888889 +lon_0=168.606267 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Karamea Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.28991152777778 +lon_0=172.1090281944444 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Lindis Peak Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-44.73526797222222 +lon_0=169.4677550833333 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Marlborough Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.54448666666666 +lon_0=173.8020741111111 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Mount Eden Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-36.87986527777778 +lon_0=174.7643393611111 +k=0.999900 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Mount Nicholas Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.13290258333333 +lon_0=168.3986411944444 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Mount Pleasant Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.59063758333333 +lon_0=172.7271935833333 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Mount York Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.56372616666666 +lon_0=167.7388617777778 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Nelson Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.27454472222222 +lon_0=173.2993168055555 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 North Taieri Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.86151336111111 +lon_0=170.2825891111111 +k=0.999960 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Observation Point Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.81619661111111 +lon_0=170.6285951666667 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Okarito Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.11012813888889 +lon_0=170.2609258333333 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Poverty Bay Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-38.62470277777778 +lon_0=177.8856362777778 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Taranaki Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-39.13575830555556 +lon_0=174.22801175 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Timaru Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-44.40222036111111 +lon_0=171.0572508333333 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Tuhirangi Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-39.51247038888889 +lon_0=175.6400368055556 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 UTM Zone 59S"
p.PROJ4 = "+proj=utm +zone=59 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 UTM Zone 60S"
p.PROJ4 = "+proj=utm +zone=60 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Wairarapa Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-40.92553263888889 +lon_0=175.6473496666667 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Wanganui Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-40.24194713888889 +lon_0=175.4880996111111 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 1949 Wellington Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.30131963888888 +lon_0=174.7766231111111 +k=1.000000 +x_0=300000 +y_0=700000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Amuri Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-42.68888888888888 +lon_0=173.01 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Bay of Plenty Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-37.76111111111111 +lon_0=176.4661111111111 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Bluff Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-46.6 +lon_0=168.3427777777778 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Buller Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.81055555555555 +lon_0=171.5811111111111 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Chatham Island Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-44 +lon_0=-176.5 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Collingwood Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-40.71472222222223 +lon_0=172.6719444444444 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Gawler Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.74861111111111 +lon_0=171.3605555555555 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Grey Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-42.33361111111111 +lon_0=171.5497222222222 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Hawkes Bay Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-39.65083333333333 +lon_0=176.6736111111111 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Hokitika Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-42.88611111111111 +lon_0=170.9797222222222 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Jacksons Bay Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.97777777777778 +lon_0=168.6061111111111 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Karamea Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.28972222222222 +lon_0=172.1088888888889 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Lindis Peak Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-44.735 +lon_0=169.4675 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Marlborough Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.54444444444444 +lon_0=173.8019444444444 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Mount Eden Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-36.87972222222222 +lon_0=174.7641666666667 +k=0.999900 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Mount Nicholas Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.13277777777778 +lon_0=168.3986111111111 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Mount Pleasant Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.59055555555556 +lon_0=172.7269444444445 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Mount York Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.56361111111111 +lon_0=167.7386111111111 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Nelson Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.27444444444444 +lon_0=173.2991666666667 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 New Zealand Transverse Mercator"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=173 +k=0.999600 +x_0=1600000 +y_0=10000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 North Taieri Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.86138888888889 +lon_0=170.2825 +k=0.999960 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Observation Point Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-45.81611111111111 +lon_0=170.6283333333333 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Okarito Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-43.11 +lon_0=170.2608333333333 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Poverty Bay Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-38.62444444444444 +lon_0=177.8855555555556 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Taranaki Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-39.13555555555556 +lon_0=174.2277777777778 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Timaru Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-44.40194444444445 +lon_0=171.0572222222222 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Tuhirangi Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-39.51222222222222 +lon_0=175.64 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 UTM Zone 59S"
p.PROJ4 = "+proj=utm +zone=59 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 UTM Zone 60S"
p.PROJ4 = "+proj=utm +zone=60 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Wairarapa Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-40.92527777777777 +lon_0=175.6472222222222 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Wanganui Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-40.24194444444444 +lon_0=175.4880555555555 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - New Zealand"
p.Name = "NZGD 2000 Wellington Circuit"
p.PROJ4 = "+proj=tmerc +lat_0=-41.3011111111111 +lon_0=174.7763888888889 +k=1.000000 +x_0=400000 +y_0=800000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Baerum Kommune"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=10.72291666666667 +k=1.000000 +x_0=19999.32 +y_0=-202977.79 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Bergenhalvoen"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=6.05625 +k=1.000000 +x_0=100000 +y_0=-200000 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=6.056249999999999 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=8.389583333333333 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=10.72291666666667 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=13.22291666666667 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=16.88958333333333 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=20.88958333333333 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=24.88958333333333 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Norway Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=29.05625 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Kommune"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=10.72291666666667 +k=1.000000 +x_0=0 +y_0=-212979.18 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=-15.38958333333334 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=-13.05625 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=-10.72291666666667 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=-8.22291666666667 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=-4.556250000000003 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=-0.5562500000000004 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=3.44375 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Norway"
p.Name = "NGO 1948 Oslo Norway Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=58 +lon_0=7.610416666666659 +k=1.000000 +x_0=0 +y_0=0 +a=6377492.018 +b=6356173.508712696 +pm=10.72291666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT38 0 gon"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18.05827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT38 25 gon O"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=20.30827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT38 25 gon V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15.80827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT38 5 gon O"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=22.55827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT38 5 gon V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=13.55827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT38 75 gon V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=11.30827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT90 0 gon"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18.05827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT90 25 gon O"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=20.30827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT90 25 gon V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15.80827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT90 5 gon O"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=22.55827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT90 5 gon V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=13.55827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "RT90 75 gon V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=11.30827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 12 00"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 13 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=13.5 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 14 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=14.25 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 15 00"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 15 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15.75 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 16 30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=16.5 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 17 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=17.25 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 18 00"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 18 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18.75 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 20 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=20.25 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 21 45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21.75 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 23 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=23.25 +k=1.000000 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids - Sweden"
p.Name = "SWEREF99 TM"
p.PROJ4 = "+proj=utm +zone=33 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Abidjan 1987 TM 5 NW"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-5 +k=0.999600 +x_0=500000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Accra Ghana Grid"
p.PROJ4 = "+proj=tmerc +lat_0=4.666666666666667 +lon_0=-1 +k=0.999750 +x_0=274319.7391633579 +y_0=0 +a=6378300 +b=6356751.689189189 +to_meter=0.3047997101815088 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Accra TM 1 NW"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-1 +k=0.999600 +x_0=500000 +y_0=0 +a=6378300 +b=6356751.689189189 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "National Grids"
        p.Name = "Greek Grid"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999600 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Ain el Abd Aramco Lambert"
p.PROJ4 = "+proj=lcc +lat_1=17 +lat_2=33 +lat_0=25.08951 +lon_0=48 +x_0=0 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "American Samoa 1962 Samoa Lambert"
p.PROJ4 = "+proj=lcc +lat_1=-14.26666666666667 +lat_0=-14.26666666666667 +lon_0=-170 +k_0=1 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Anguilla 1957 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Antigua 1943 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-72 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-69 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-66 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-63 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-60 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-57 +k=1.000000 +x_0=6500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Argentina Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-54 +k=1.000000 +x_0=7500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Austria (Ferro) Central Zone"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48.66666666666667 +k=1.000000 +x_0=0 +y_0=0 +ellps=bessel +pm=-17.66666666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Austria (Ferro) East Zone"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=51.66666666666667 +k=1.000000 +x_0=0 +y_0=0 +ellps=bessel +pm=-17.66666666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Austria (Ferro) West Zone"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45.66666666666667 +k=1.000000 +x_0=0 +y_0=0 +ellps=bessel +pm=-17.66666666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Bahrain State Grid"
p.PROJ4 = "+proj=utm +zone=39 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Barbados 1938 Barbados Grid"
p.PROJ4 = "+proj=tmerc +lat_0=13.17638888888889 +lon_0=-59.55972222222222 +k=0.999999 +x_0=30000 +y_0=75000 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Barbados 1938 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Batavia NEIEZ"
p.PROJ4 = "+proj=merc +lat_ts=4.45405154589751 +lon_0=110 +k=1.000000 +x_0=3900000 +y_0=900000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Batavia TM 109 SE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=109 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Belge Lambert 1950"
p.PROJ4 = "+proj=lcc +lat_1=49.83333333333334 +lat_2=51.16666666666666 +lat_0=90 +lon_0=-4.367975 +x_0=150000 +y_0=5400000 +ellps=intl +pm=4.367975 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Belge Lambert 1972"
p.PROJ4 = "+proj=lcc +lat_1=49.8333339 +lat_2=51.16666733333333 +lat_0=90 +lon_0=4.367486666666666 +x_0=150000.01256 +y_0=5400088.4378 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Bermuda 2000 National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=32 +lon_0=-64.75 +k=1.000000 +x_0=550000 +y_0=100000 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Bern 1898 Bern LV03C"
p.PROJ4 = "+proj=somerc +lat_0=46.95240555555556 +lon_0=-7.439583333333333 +x_0=0 +y_0=0 +ellps=bessel +pm=7.439583333333333 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "British National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=49 +lon_0=-2 +k=0.999601 +x_0=400000 +y_0=-100000 +ellps=airy +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Camacupa TM 11 30 SE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=11.5 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Camacupa TM 12 SE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Carthage TM 11 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9.900000000000002 +k=0.999600 +x_0=500000 +y_0=0 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Centre France"
p.PROJ4 = "+proj=lcc +lat_1=46.8 +lat_0=46.8 +lon_0=-2.337229166666667 +k_0=0.99987742 +x_0=600000 +y_0=200000 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "CH1903 LV03"
p.PROJ4 = "+proj=somerc +lat_0=46.95240555555556 +lon_0=7.439583333333333 +x_0=600000 +y_0=200000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "CH1903+ LV95"
p.PROJ4 = "+proj=somerc +lat_0=46.95240555555556 +lon_0=7.439583333333333 +x_0=2600000 +y_0=1200000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Chos Malal 1914 Argentina 2"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-69 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Colombia Bogota Zone"
p.PROJ4 = "+proj=tmerc +lat_0=4.599047222222222 +lon_0=-74.08091666666667 +k=1.000000 +x_0=1000000 +y_0=1000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Colombia E Central Zone"
p.PROJ4 = "+proj=tmerc +lat_0=4.599047222222222 +lon_0=-71.08091666666667 +k=1.000000 +x_0=1000000 +y_0=1000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Colombia East Zone"
p.PROJ4 = "+proj=tmerc +lat_0=4.599047222222222 +lon_0=-68.08091666666667 +k=1.000000 +x_0=1000000 +y_0=1000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Colombia West Zone"
p.PROJ4 = "+proj=tmerc +lat_0=4.599047222222222 +lon_0=-77.08091666666667 +k=1.000000 +x_0=1000000 +y_0=1000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Corse"
p.PROJ4 = "+proj=lcc +lat_1=42.165 +lat_0=42.165 +lon_0=-2.337229166666667 +k_0=0.99994471 +x_0=234.358 +y_0=185861.369 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Datum 73 Hayford Gauss IGeoE"
p.PROJ4 = "+proj=tmerc +lat_0=39.66666666666666 +lon_0=-8.131906111111112 +k=1.000000 +x_0=200180.598 +y_0=299913.01 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Datum 73 Hayford Gauss IPCC"
p.PROJ4 = "+proj=tmerc +lat_0=39.66666666666666 +lon_0=-8.131906111111112 +k=1.000000 +x_0=180.598 +y_0=-86.99 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Deir ez Zor Levant Stereographic"
p.PROJ4 = "+a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Deir ez Zor Levant Zone"
p.PROJ4 = "+a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Deir ez Zor Syria Lambert"
p.PROJ4 = "+proj=lcc +lat_1=34.65 +lat_0=34.65 +lon_0=37.35 +k_0=0.9996256 +x_0=300000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "DHDN 3 Degree Gauss Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=3 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "DHDN 3 Degree Gauss Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=6 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "DHDN 3 Degree Gauss Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "DHDN 3 Degree Gauss Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "DHDN 3 Degree Gauss Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Dominica 1945 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Douala 1948 AOF West"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=10.5 +k=0.999000 +x_0=1000000 +y_0=1000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 France EuroLambert"
p.PROJ4 = "+proj=lcc +lat_1=46.8 +lat_0=46.8 +lon_0=2.337229166666667 +k_0=0.99987742 +x_0=600000 +y_0=2200000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM 0 N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=0 +k=0.999600 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM 5 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=5 +k=0.999600 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM27"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM30"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM33"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM36"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM39"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM42"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 TM45"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=1.000000 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=0.999600 +x_0=10500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=0.999600 +x_0=11500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=0.999600 +x_0=12500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=39 +k=0.999600 +x_0=13500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 14"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=42 +k=0.999600 +x_0=14500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 15"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=45 +k=0.999600 +x_0=15500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ED 1950 Turkey 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=0.999600 +x_0=9500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Egypt Blue Belt"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=35 +k=1.000000 +x_0=300000 +y_0=1100000 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Egypt Extended Purple Belt"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=27 +k=1.000000 +x_0=700000 +y_0=1200000 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Egypt Purple Belt"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=27 +k=1.000000 +x_0=700000 +y_0=200000 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Egypt Red Belt"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=31 +k=1.000000 +x_0=615000 +y_0=810000 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 10"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=19 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 11"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 12"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=23 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 13"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=25 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=11 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=13 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 Libya 9"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=17 +k=0.999900 +x_0=200000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ELD 1979 TM 12 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=0.999600 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Estonia 1997 Estonia National Grid"
p.PROJ4 = "+proj=lcc +lat_1=58 +lat_2=59.33333333333334 +lat_0=57.51755393055556 +lon_0=24 +x_0=500000 +y_0=6375000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Estonian Coordinate System of 1992"
p.PROJ4 = "+proj=lcc +lat_1=58 +lat_2=59.33333333333334 +lat_0=57.51755393055556 +lon_0=24 +x_0=500000 +y_0=6375000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRF 1989 TM Baltic 1993"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999600 +x_0=500000 +y_0=0 +ellps=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Kp2000 Bornholm"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=900000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Kp2000 Jutland"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9.5 +k=0.999950 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Kp2000 Zealand"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=0.999950 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Poland CS2000 Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999923 +x_0=5500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Poland CS2000 Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=0.999923 +x_0=6500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Poland CS2000 Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=0.999923 +x_0=7500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Poland CS2000 Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999923 +x_0=8500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 Poland CS92"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=19 +k=0.999300 +x_0=500000 +y_0=-5300000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 TM 30 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=0.999600 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 TM Baltic 1993"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999600 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 UWPP 1992"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=19 +k=0.999300 +x_0=500000 +y_0=-5300000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 UWPP 2000 PAS 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999923 +x_0=5500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 UWPP 2000 PAS 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=0.999923 +x_0=6500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 UWPP 2000 PAS 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=0.999923 +x_0=7500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ETRS 1989 UWPP 2000 PAS 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999923 +x_0=8500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "EUREF FIN TM35FIN"
p.PROJ4 = "+proj=utm +zone=35 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Everest Modified 1969 RSO Malaya Meters"
p.PROJ4 = "+a=6377295.664 +b=6356094.667915204 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "FD 1958 Iraq"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_0=32.5 +lon_0=45 +k_0=0.9987864077700001 +x_0=1500000 +y_0=1166200 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Finland Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Finland Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Finland Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Finland Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "France I"
p.PROJ4 = "+proj=lcc +lat_1=49.49999999999999 +lat_0=49.49999999999999 +lon_0=-2.337229166666667 +k_0=0.999877341 +x_0=600000 +y_0=1200000 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "France II"
p.PROJ4 = "+proj=lcc +lat_1=46.8 +lat_0=46.8 +lon_0=-2.337229166666667 +k_0=0.99987742 +x_0=600000 +y_0=2200000 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "France III"
p.PROJ4 = "+proj=lcc +lat_1=44.09999999999999 +lat_0=44.09999999999999 +lon_0=-2.337229166666667 +k_0=0.999877499 +x_0=600000 +y_0=3200000 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "France IV"
p.PROJ4 = "+proj=lcc +lat_1=42.165 +lat_0=42.165 +lon_0=-2.337229166666667 +k_0=0.99994471 +x_0=234.358 +y_0=185861.369 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Germany Zone 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=3 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Germany Zone 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=6 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Germany Zone 3"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=1.000000 +x_0=3500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Germany Zone 4"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=12 +k=1.000000 +x_0=4500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Germany Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Ghana Metre Grid"
p.PROJ4 = "+proj=tmerc +lat_0=4.666666666666667 +lon_0=-1 +k=0.999750 +x_0=274319.51 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
        p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Grenada 1953 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Guernsey Grid"
p.PROJ4 = "+proj=tmerc +lat_0=49.5 +lon_0=-2.416666666666667 +k=0.999997 +x_0=47000 +y_0=50000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Gunung Segara NEIEZ"
p.PROJ4 = "+proj=merc +lat_ts=4.45405154589751 +lon_0=110 +k=1.000000 +x_0=3900000 +y_0=900000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Hanoi 1972 GK 106 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=106 +k=1.000000 +x_0=500000 +y_0=0 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "HD 1972 Egyseges Orszagos Vetuleti"
p.PROJ4 = "+proj=somerc +lat_0=47.14439372222 +lon_0=19.048571778 +x_0=650000 +y_0=200000 +ellps=GRS67 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Helle 1954 Jan Mayen Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-8.5 +k=1.000000 +x_0=50000 +y_0=-7800000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Hito XVIII 1963 Argentina 2"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-69 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Hong Kong 1980 Grid"
p.PROJ4 = "+proj=tmerc +lat_0=22.31213333333334 +lon_0=114.1785555555556 +k=1.000000 +x_0=836694.0500000001 +y_0=819069.8000000001 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Indian 1960 TM 106NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=106 +k=0.999600 +x_0=500000 +y_0=0 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "IRENET95 Irish Tranverse Mercator"
p.PROJ4 = "+proj=tmerc +lat_0=53.5 +lon_0=-8 +k=0.999820 +x_0=600000 +y_0=750000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Irish National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=53.5 +lon_0=-8 +k=1.000035 +x_0=200000 +y_0=250000 +a=6377340.189 +b=6356034.447938534 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "ISN 1993 Lambert 1993"
p.PROJ4 = "+proj=lcc +lat_1=64.25 +lat_2=65.75 +lat_0=65 +lon_0=-19 +x_0=500000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Israel TM Grid"
p.PROJ4 = "+proj=tmerc +lat_0=31.73439361111111 +lon_0=35.20451694444445 +k=1.000007 +x_0=219529.584 +y_0=626907.39 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Jamaica 1875 Old Grid"
p.PROJ4 = "+proj=lcc +lat_1=18 +lat_0=18 +lon_0=-77 +k_0=1 +x_0=550000 +y_0=400000 +a=6378249.138 +b=6356514.959419348 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Jamaica Grid"
p.PROJ4 = "+proj=lcc +lat_1=18 +lat_0=18 +lon_0=-77 +k_0=1 +x_0=250000 +y_0=150000 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Jordan JTM"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=37 +k=0.999800 +x_0=500000 +y_0=-3000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kandawala Ceylon Belt Indian Yards 1937"
p.PROJ4 = "+proj=tmerc +lat_0=7.000480277777778 +lon_0=80.77171111111112 +k=1.000000 +x_0=160933.56048 +y_0=160933.56048 +a=6377276.345 +b=6356075.41314024 +to_meter=0.91439523 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kandawala Ceylon Belt Meters"
p.PROJ4 = "+proj=tmerc +lat_0=7.000480277777778 +lon_0=80.77171111111112 +k=1.000000 +x_0=160933.56048 +y_0=160933.56048 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kertau RSO Malaya Chains"
p.PROJ4 = "+a=6377304.063 +b=6356103.038993155 +to_meter=20.11678249437587 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kertau RSO Malaya Meters"
p.PROJ4 = "+a=6377304.063 +b=6356103.038993155 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kertau Singapore Grid"
p.PROJ4 = "+proj=cass +lat_0=1.287646666666667 +lon_0=103.8530022222222 +x_0=30000 +y_0=30000 +a=6377304.063 +b=6356103.038993155 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "KOC Lambert"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_0=32.5 +lon_0=45 +k_0=0.998786407767 +x_0=1500000 +y_0=1166200 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Korean 1985 Korea Central Belt"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=127 +k=1.000000 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Korean 1985 Korea East Belt"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=129 +k=1.000000 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Korean 1985 Korea West Belt"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=125 +k=1.000000 +x_0=200000 +y_0=500000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "KUDAMS KTM"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48 +k=0.999600 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kuwait Oil Co - Lambert"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_0=32.5 +lon_0=45 +k_0=0.998786407767 +x_0=1500000 +y_0=1166200 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Kuwait Utility KTM"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=48 +k=0.999600 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lake Maracaibo Grid M1"
p.PROJ4 = "+proj=lcc +lat_1=10.16666666666667 +lat_0=10.16666666666667 +lon_0=-71.60561777777777 +k_0=1 +x_0=0 +y_0=-52684.972 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lake Maracaibo Grid M3"
p.PROJ4 = "+proj=lcc +lat_1=10.16666666666667 +lat_0=10.16666666666667 +lon_0=-71.60561777777777 +k_0=1 +x_0=500000 +y_0=447315.028 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lake Maracaibo Grid"
p.PROJ4 = "+proj=lcc +lat_1=10.16666666666667 +lat_0=10.16666666666667 +lon_0=-71.60561777777777 +k_0=1 +x_0=200000 +y_0=147315.028 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lake Maracaibo La Rosa Grid"
p.PROJ4 = "+proj=lcc +lat_1=10.16666666666667 +lat_0=10.16666666666667 +lon_0=-71.60561777777777 +k_0=1 +x_0=-17044 +y_0=-23139.97 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lietuvos Koordinaciu Sistema"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999800 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lisboa Bessel Bonne"
p.PROJ4 = "+proj=bonne +lon_0=-8.131906111111112 +lat_1=39.66666666666666 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lisboa Hayford Gauss IGeoE"
p.PROJ4 = "+proj=tmerc +lat_0=39.66666666666666 +lon_0=-8.131906111111112 +k=1.000000 +x_0=200000 +y_0=300000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Lisboa Hayford Gauss IPCC"
p.PROJ4 = "+proj=tmerc +lat_0=39.66666666666666 +lon_0=-8.131906111111112 +k=1.000000 +x_0=0 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Locodjo 1965 TM 5 NW"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-5 +k=0.999600 +x_0=500000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Luxembourg 1930 Gauss"
p.PROJ4 = "+proj=tmerc +lat_0=49.83333333333334 +lon_0=6.166666666666667 +k=1.000000 +x_0=80000 +y_0=100000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Madrid 1870 Madrid Spain"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_0=40 +lon_0=3.687938888888889 +k_0=0.9988085293 +x_0=600000 +y_0=600000 +a=6378298.3 +b=6356657.142669561 +pm=-3.687938888888889 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Makassar NEIEZ"
p.PROJ4 = "+proj=merc +lat_ts=4.45405154589751 +lon_0=110 +k=1.000000 +x_0=3900000 +y_0=900000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI 3 Degree Gauss Zone 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=1.000000 +x_0=5500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI 3 Degree Gauss Zone 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=1.000000 +x_0=6500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI 3 Degree Gauss Zone 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=7500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI 3 Degree Gauss Zone 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=8500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI Austria Lambert"
p.PROJ4 = "+proj=lcc +lat_1=46 +lat_2=49 +lat_0=47.5 +lon_0=13.33333333333333 +x_0=400000 +y_0=400000 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI Balkans 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999900 +x_0=5500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI Balkans 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=0.999900 +x_0=6500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI Balkans 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999900 +x_0=8500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI Balkans 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999900 +x_0=8500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI M28"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=10.33333333333333 +k=1.000000 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI M31"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=13.33333333333333 +k=1.000000 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI M34"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=16.33333333333334 +k=1.000000 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "MGI Slovenia Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999900 +x_0=500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Monte Mario (Rome) Italy 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-15.90466666333333 +k=0.999600 +x_0=1500000 +y_0=0 +ellps=intl +pm=12.45233333333333 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Monte Mario (Rome) Italy 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-9.90466666333333 +k=0.999600 +x_0=2520000 +y_0=0 +ellps=intl +pm=12.45233333333333 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Monte Mario Italy 1"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=0.999600 +x_0=1500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Monte Mario Italy 2"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999600 +x_0=2520000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Montserrat 1958 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Mount Dillon Tobago Grid"
p.PROJ4 = "+proj=cass +lat_0=11.25217861111111 +lon_0=-59.68600888888889 +x_0=37718.66154375 +y_0=36209.915082 +a=6378293.639 +b=6356617.98149216 +to_meter=0.2011661949 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1927 Cuba Norte"
p.PROJ4 = "+proj=lcc +lat_1=22.35 +lat_0=22.35 +lon_0=-81 +k_0=0.99993602 +x_0=500000 +y_0=280296.016 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1927 Cuba Sur"
p.PROJ4 = "+proj=lcc +lat_1=20.71666666666667 +lat_0=20.71666666666667 +lon_0=-76.83333333333333 +k_0=0.99994848 +x_0=500000 +y_0=229126.939 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1927 Guatemala Norte"
p.PROJ4 = "+proj=lcc +lat_1=16.81666666666667 +lat_0=16.81666666666667 +lon_0=-90.33333333333333 +k_0=0.99992226 +x_0=500000 +y_0=292209.579 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1927 Guatemala Sur"
p.PROJ4 = "+proj=lcc +lat_1=14.9 +lat_0=14.9 +lon_0=-90.33333333333333 +k_0=0.99989906 +x_0=500000 +y_0=325992.681 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1927 Michigan GeoRef (Meters)"
p.PROJ4 = "+proj=omerc +lat_0=45.30916666666666 +lonc=-86 +alpha=337.255555555556 +k=0.9996 +x_0=2546731.496 +y_0=-4354009.816 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "National Grids"
        p.Name = "NAD 1983 Michigan GeoReferenced (Meters)"
        p.PROJ4 = "+proj=omerc +lat_0=45.30916666666666 +lonc=-86 +alpha=337.25556 +k=0.9996 +x_0=2546731.496 +y_0=-4354009.816 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
        ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1927 Michigan GeoRef (US feet)"
p.PROJ4 = "+proj=omerc +lat_0=45.30916666666666 +lonc=-86 +alpha=337.255555555556 +k=0.9996 +x_0=2546731.495961392 +y_0=-4354009.816002033 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1983 HARN Guam Map Grid"
p.PROJ4 = "+proj=tmerc +lat_0=13.5 +lon_0=144.75 +k=1.000000 +x_0=100000 +y_0=200000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1983 Michigan GeoRef (Meters)"
p.PROJ4 = "+proj=omerc +lat_0=45.30916666666666 +lonc=-86 +alpha=337.255555555556 +k=0.9996 +x_0=2546731.496 +y_0=-4354009.816 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NAD 1983 Michigan GeoRef (US feet)"
p.PROJ4 = "+proj=omerc +lat_0=45.30916666666666 +lonc=-86 +alpha=337.255555555556 +k=0.9996 +x_0=2546731.495961392 +y_0=-4354009.816002033 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "New Zealand Map Grid"
p.PROJ4 = "+proj=nzmg +lat_0=-41 +lon_0=173 +x_0=2510000 +y_0=6023150 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "New Zealand North Island"
p.PROJ4 = "+proj=tmerc +lat_0=-39 +lon_0=175.5 +k=1.000000 +x_0=274319.5243848086 +y_0=365759.3658464114 +ellps=intl +to_meter=0.9143984146160287 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "New Zealand South Island"
p.PROJ4 = "+proj=tmerc +lat_0=-44 +lon_0=171.5 +k=1.000000 +x_0=457199.2073080143 +y_0=457199.2073080143 +ellps=intl +to_meter=0.9143984146160287 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nigeria East Belt"
p.PROJ4 = "+proj=tmerc +lat_0=4 +lon_0=12.5 +k=0.999750 +x_0=1110369.7 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nigeria Mid Belt"
p.PROJ4 = "+proj=tmerc +lat_0=4 +lon_0=8.5 +k=0.999750 +x_0=670553.98 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nigeria West Belt"
p.PROJ4 = "+proj=tmerc +lat_0=4 +lon_0=4.5 +k=0.999750 +x_0=230738.26 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Algerie (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_0=36 +lon_0=2.7 +k_0=0.999625544 +x_0=500135 +y_0=300090 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Algerie Ancienne (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_0=36 +lon_0=2.7 +k_0=0.999625544 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Algerie ancienne"
p.PROJ4 = "+proj=lcc +lat_1=37 +lat_0=37 +lon_0=3 +k_0=0.999625769 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Algerie"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_0=36 +lon_0=2.7 +k_0=0.999625544 +x_0=500135 +y_0=300090 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord de Guerre"
p.PROJ4 = "+proj=lcc +lat_1=49.49999999999999 +lat_0=49.49999999999999 +lon_0=3.062770833333333 +k_0=0.9995090800000001 +x_0=500000 +y_0=300000 +a=6376523 +b=6355862.933255573 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord France"
p.PROJ4 = "+proj=lcc +lat_1=49.49999999999999 +lat_0=49.49999999999999 +lon_0=-2.337229166666667 +k_0=0.999877341 +x_0=600000 +y_0=200000 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Maroc (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_0=33.3 +lon_0=-5.4 +k_0=0.999625769 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Maroc"
p.PROJ4 = "+proj=lcc +lat_1=37 +lat_0=37 +lon_0=-6 +k_0=0.999625769 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Nord Tunisie"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_0=36 +lon_0=9.899999999999999 +k_0=0.999625544 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NTF France I (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=49.5 +lat_0=49.5 +lon_0=2.337229166666667 +k_0=0.999877341 +x_0=600000 +y_0=1200000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NTF France II (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=46.8 +lat_0=46.8 +lon_0=2.337229166666667 +k_0=0.99987742 +x_0=600000 +y_0=2200000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NTF France III (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=44.1 +lat_0=44.1 +lon_0=2.337229166666667 +k_0=0.999877499 +x_0=600000 +y_0=3200000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "NTF France IV (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=42.165 +lat_0=42.165 +lon_0=2.337229166666667 +k_0=0.99994471 +x_0=234.358 +y_0=185861.369 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Observatorio Meteorologico 1965 Macau Grid"
p.PROJ4 = "+proj=tmerc +lat_0=22.21239722222222 +lon_0=113.5364694444444 +k=1.000000 +x_0=20000 +y_0=20000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "OSNI 1952 Irish National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=53.5 +lon_0=-8 +k=1.000035 +x_0=200000 +y_0=250000 +ellps=airy +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Palestine 1923 Israel CS Grid"
p.PROJ4 = "+proj=cass +lat_0=31.73409694444445 +lon_0=35.21208055555556 +x_0=170251.555 +y_0=1126867.909 +a=6378300.79 +b=6356566.430000036 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Palestine 1923 Palestine Belt"
p.PROJ4 = "+proj=tmerc +lat_0=31.73409694444445 +lon_0=35.21208055555556 +k=1.000000 +x_0=170251.555 +y_0=1126867.909 +a=6378300.79 +b=6356566.430000036 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Palestine 1923 Palestine Grid"
p.PROJ4 = "+proj=cass +lat_0=31.73409694444445 +lon_0=35.21208055555556 +x_0=170251.555 +y_0=126867.909 +a=6378300.79 +b=6356566.430000036 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Pampa del Castillo Argentina 2"
p.PROJ4 = "+proj=tmerc +lat_0=-90 +lon_0=-69 +k=1.000000 +x_0=2500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Peru Central Zone"
p.PROJ4 = "+proj=tmerc +lat_0=-9.5 +lon_0=-76 +k=0.999330 +x_0=720000 +y_0=1039979.159 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Peru East Zone"
p.PROJ4 = "+proj=tmerc +lat_0=-9.5 +lon_0=-70.5 +k=0.999530 +x_0=1324000 +y_0=1040084.558 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Peru West Zone"
p.PROJ4 = "+proj=tmerc +lat_0=-6 +lon_0=-80.5 +k=0.999830 +x_0=222000 +y_0=1426834.743 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Philippines Zone I"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=117 +k=0.999950 +x_0=500000 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Philippines Zone II"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=119 +k=0.999950 +x_0=500000 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Philippines Zone III"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=121 +k=0.999950 +x_0=500000 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Philippines Zone IV"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=123 +k=0.999950 +x_0=500000 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Philippines Zone V"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=125 +k=0.999950 +x_0=500000 +y_0=0 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Piton des Neiges TM Reunion"
p.PROJ4 = "+proj=tmerc +lat_0=-21.11666666666667 +lon_0=55.53333333333333 +k=1.000000 +x_0=50000 +y_0=160000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Portuguese National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=39.66666666666666 +lon_0=10.13190611111111 +k=1.000000 +x_0=200000 +y_0=300000 +ellps=intl +pm=-9.131906111111112 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "PSAD 1956 ICN Regional"
p.PROJ4 = "+proj=lcc +lat_1=3 +lat_2=9 +lat_0=6 +lon_0=-66 +x_0=1000000 +y_0=1000000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Qatar 1948 Qatar Grid"
p.PROJ4 = "+proj=cass +lat_0=25.38236111111111 +lon_0=50.76138888888889 +x_0=100000 +y_0=100000 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Qatar National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=24.45 +lon_0=51.21666666666667 +k=0.999990 +x_0=200000 +y_0=300000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Rassadiran Nakhl e Taqi"
p.PROJ4 = "+proj=omerc +lat_0=27.56882880555555 +lonc=52.60353916666667 +alpha=0.5716611944444444 +k=0.999895934 +x_0=658377.437 +y_0=3044969.194 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
        p.Name = "Dutch (RD)"
        'New projection string, CDM 3/9/2006
        'p.PROJ4 = "+ellps=bessel +units=m +no_defs "
        p.PROJ4 = "+proj=sterea +lat_0=52.15616055555555 +lon_0=5.38763888888889 +k=0.999908 +x_0=155000 +y_0=463000 +ellps=bessel  +units=m +towgs84=565.2369,50.0087,465.658,-0.406857330322398,0.350732676542563,-1.8703473836068,4.0812 +no_defs +to +proj=latlong +datum=WGS84 "
        ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "RGF 1993 Lambert-93"
p.PROJ4 = "+proj=lcc +lat_1=44 +lat_2=49 +lat_0=46.5 +lon_0=3 +x_0=700000 +y_0=6600000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "RGNC 1991 Lambert New Caledonia"
p.PROJ4 = "+proj=lcc +lat_1=-20.66666666666667 +lat_2=-22.33333333333333 +lat_0=-21.5 +lon_0=166 +x_0=400000 +y_0=300000 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Rijksdriehoekstelsel"
p.PROJ4 = "+ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Roma 1940 Gauss Boaga Est"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999600 +x_0=2520000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Roma 1940 Gauss Boaga Ovest"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=9 +k=0.999600 +x_0=1500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "RT90 2.5 gon West"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15.80827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "S-JTSK (Ferro) Krovak EastNorth"
p.PROJ4 = "+proj=krovak +lat_0=49.5 +lon_0=60.16666666666667 +alpha=30.28813975277778 +k=0.9999 +x_0=0 +y_0=0 +ellps=bessel +pm=-17.66666666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "S-JTSK (Ferro) Krovak"
p.PROJ4 = "+proj=krovak +lat_0=49.5 +lon_0=60.16666666666667 +alpha=30.28813975277778 +k=0.9999 +x_0=0 +y_0=0 +ellps=bessel +pm=-17.66666666666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "S-JTSK Krovak EastNorth"
p.PROJ4 = "+proj=krovak +lat_0=49.5 +lon_0=24.83333333333333 +alpha=30.28813975277778 +k=0.9999 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "S-JTSK Krovak"
p.PROJ4 = "+proj=krovak +lat_0=49.5 +lon_0=24.83333333333333 +alpha=30.28813975277778 +k=0.9999 +x_0=0 +y_0=0 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "SAD 1969 Brazil Polyconic"
p.PROJ4 = "+proj=poly +lat_0=0 +lon_0=-54 +x_0=5000000 +y_0=10000000 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sahara (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=26.1 +lat_0=26.1 +lon_0=-5.4 +k_0=0.9996 +x_0=1200000 +y_0=400000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sahara"
p.PROJ4 = "+proj=lcc +lat_1=29 +lat_0=29 +lon_0=-6 +k_0=0.9996 +x_0=1200000 +y_0=400000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sierra Leone 1924 New Colony Grid"
p.PROJ4 = "+proj=tmerc +lat_0=6.666666666666667 +lon_0=-12 +k=1.000000 +x_0=152399.8550907544 +y_0=0 +a=6378300 +b=6356751.689189189 +to_meter=0.3047997101815088 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sierra Leone 1924 New War Office Grid"
p.PROJ4 = "+proj=tmerc +lat_0=6.666666666666667 +lon_0=-12 +k=1.000000 +x_0=243839.7681452071 +y_0=182879.8261089053 +a=6378300 +b=6356751.689189189 +to_meter=0.3047997101815088 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "St Kitts 1955 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "St Lucia 1955 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "St Vincent 1945 British West Indies Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-62 +k=0.999500 +x_0=400000 +y_0=0 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Stereo 1933"
p.PROJ4 = "+ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Stereo 1970"
p.PROJ4 = "+ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud Algerie (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_0=33.3 +lon_0=2.7 +k_0=0.999625769 +x_0=500135 +y_0=300090 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud Algerie Ancienne Degree"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_0=33.3 +lon_0=2.7 +k_0=0.999625769 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud Algerie"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_0=33.3 +lon_0=2.7 +k_0=0.999625769 +x_0=500135 +y_0=300090 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud France"
p.PROJ4 = "+proj=lcc +lat_1=44.09999999999999 +lat_0=44.09999999999999 +lon_0=-2.337229166666667 +k_0=0.999877499 +x_0=600000 +y_0=200000 +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud Maroc (degrees)"
p.PROJ4 = "+proj=lcc +lat_1=29.7 +lat_0=29.7 +lon_0=-5.4 +k_0=0.9996155960000001 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud Maroc"
p.PROJ4 = "+proj=lcc +lat_1=33 +lat_0=33 +lon_0=-6 +k_0=0.9996155960000001 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Sud Tunisie"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_0=33.3 +lon_0=9.899999999999999 +k_0=0.999625769 +x_0=500000 +y_0=300000 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Swedish National Grid"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-20.30827777777778 +k=1.000000 +x_0=1500000 +y_0=0 +ellps=bessel +pm=18.05827777777778 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Timbalai 1948 RSO Borneo Chains"
p.PROJ4 = "+ellps=evrstSS +to_meter=20.11676512155263 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Timbalai 1948 RSO Borneo Feet"
p.PROJ4 = "+ellps=evrstSS +to_meter=0.3047994715386762 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Timbalai 1948 RSO Borneo Meters"
p.PROJ4 = "+ellps=evrstSS +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "TM75 Irish Grid"
p.PROJ4 = "+proj=tmerc +lat_0=53.5 +lon_0=-8 +k=1.000035 +x_0=200000 +y_0=250000 +a=6377340.189 +b=6356034.447938534 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Trinidad 1903 Trinidad Grid Feet Clarke"
p.PROJ4 = "+proj=cass +lat_0=10.44166666666667 +lon_0=-61.33333333333334 +x_0=86501.46380699999 +y_0=65379.0133425 +a=6378293.639 +b=6356617.98149216 +to_meter=0.304797265 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Trinidad 1903 Trinidad Grid"
p.PROJ4 = "+proj=cass +lat_0=10.44166666666667 +lon_0=-61.33333333333334 +x_0=86501.46380700001 +y_0=65379.0133425 +a=6378293.639 +b=6356617.98149216 +to_meter=0.2011661949 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "UWPP 1992"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=19 +k=0.999300 +x_0=500000 +y_0=-5300000 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "UWPP 2000 pas 5"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=15 +k=0.999923 +x_0=5500000 +y_0=0 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "UWPP 2000 pas 6"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=0.999923 +x_0=6500000 +y_0=0 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "UWPP 2000 pas 7"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=0.999923 +x_0=7500000 +y_0=0 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "UWPP 2000 pas 8"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=0.999923 +x_0=8500000 +y_0=0 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "WGS 1972 TM 106 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=106 +k=0.999600 +x_0=500000 +y_0=0 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "WGS 1984 TM 116 SE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=116 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "WGS 1984 TM 132 SE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=132 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "WGS 1984 TM 36 SE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=36 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "WGS 1984 TM 6 NE"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=6 +k=0.999600 +x_0=500000 +y_0=10000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Zanderij Suriname Old TM"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-55.68333333333333 +k=0.999600 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Zanderij Suriname TM"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-55.68333333333333 +k=0.999900 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "National Grids"
p.Name = "Zanderij TM 54 NW"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-54 +k=0.999600 +x_0=500000 +y_0=0 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "North Pole Azimuthal Equidistant"
p.PROJ4 = "+proj=aeqd +lat_0=90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "North Pole Gnomonic"
p.PROJ4 = "+proj=gnom +lat_0=90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "North Pole Lambert Azimuthal Equal Area"
p.PROJ4 = "+proj=laea +lat_0=90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "North Pole Orthographic"
p.PROJ4 = "+proj=ortho +lat_0=90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "North Pole Stereographic"
p.PROJ4 = "+proj=stere +lat_0=90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "Perroud 1950 Terre Adelie Polar Stereographic"
p.PROJ4 = "+ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "Petrels 1972 Terre Adelie Polar Stereographic"
p.PROJ4 = "+ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "South Pole Azimuthal Equidistant"
p.PROJ4 = "+proj=aeqd +lat_0=-90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "South Pole Gnomonic"
p.PROJ4 = "+proj=gnom +lat_0=-90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "South Pole Lambert Azimuthal Equal Area"
p.PROJ4 = "+proj=laea +lat_0=-90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "South Pole Orthographic"
p.PROJ4 = "+proj=ortho +lat_0=-90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "South Pole Stereographic"
p.PROJ4 = "+proj=stere +lat_0=-90 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "UPS North"
p.PROJ4 = "+proj=stere +lat_0=90 +lon_0=0 +x_0=2000000 +y_0=2000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "UPS South"
p.PROJ4 = "+proj=stere +lat_0=-90 +lon_0=0 +x_0=2000000 +y_0=2000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "WGS 1984 Antarctic Polar Stereographic"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "WGS 1984 Australian Antarctic Lambert"
p.PROJ4 = "+proj=lcc +lat_1=-68.5 +lat_2=-74.5 +lat_0=-50 +lon_0=70 +x_0=6000000 +y_0=6000000 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Polar"
p.Name = "WGS 1984 Australian Antarctic Polar Stereographic"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alabama East FIPS 0101"
p.PROJ4 = "+proj=tmerc +lat_0=30.5 +lon_0=-85.83333333333333 +k=0.999960 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alabama West FIPS 0102"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-87.5 +k=0.999933 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 1 FIPS 5001"
p.PROJ4 = "+proj=omerc +lat_0=57 +lonc=-133.6666666666667 +alpha=-36.86989764583333 +k=0.9999 +x_0=5000000.000000102 +y_0=-5000000.000000102 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 10 FIPS 5010"
p.PROJ4 = "+proj=lcc +lat_1=51.83333333333334 +lat_2=53.83333333333334 +lat_0=51 +lon_0=-176 +x_0=914401.8288036577 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 2 FIPS 5002"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-142 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 3 FIPS 5003"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-146 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 4 FIPS 5004"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-150 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 5 FIPS 5005"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-154 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 6 FIPS 5006"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-158 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 7 FIPS 5007"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-162 +k=0.999900 +x_0=213360.4267208535 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 8 FIPS 5008"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-166 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Alaska 9 FIPS 5009"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-170 +k=0.999900 +x_0=182880.3657607315 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Arizona Central FIPS 0202"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-111.9166666666667 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Arizona East FIPS 0201"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-110.1666666666667 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Arizona West FIPS 0203"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-113.75 +k=0.999933 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Arkansas North FIPS 0301"
p.PROJ4 = "+proj=lcc +lat_1=34.93333333333333 +lat_2=36.23333333333333 +lat_0=34.33333333333334 +lon_0=-92 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Arkansas South FIPS 0302"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_2=34.76666666666667 +lat_0=32.66666666666666 +lon_0=-92 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California I FIPS 0401"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=41.66666666666666 +lat_0=39.33333333333334 +lon_0=-122 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California II FIPS 0402"
p.PROJ4 = "+proj=lcc +lat_1=38.33333333333334 +lat_2=39.83333333333334 +lat_0=37.66666666666666 +lon_0=-122 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California III FIPS 0403"
p.PROJ4 = "+proj=lcc +lat_1=37.06666666666667 +lat_2=38.43333333333333 +lat_0=36.5 +lon_0=-120.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California IV FIPS 0404"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_2=37.25 +lat_0=35.33333333333334 +lon_0=-119 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California V FIPS 0405"
p.PROJ4 = "+proj=lcc +lat_1=34.03333333333333 +lat_2=35.46666666666667 +lat_0=33.5 +lon_0=-118 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California VI FIPS 0406"
p.PROJ4 = "+proj=lcc +lat_1=32.78333333333333 +lat_2=33.88333333333333 +lat_0=32.16666666666666 +lon_0=-116.25 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane California VII FIPS 0407"
p.PROJ4 = "+proj=lcc +lat_1=33.86666666666667 +lat_2=34.41666666666666 +lat_0=34.13333333333333 +lon_0=-118.3333333333333 +x_0=1276106.450596901 +y_0=1268253.006858014 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Colorado Central FIPS 0502"
p.PROJ4 = "+proj=lcc +lat_1=38.45 +lat_2=39.75 +lat_0=37.83333333333334 +lon_0=-105.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Colorado North FIPS 0501"
p.PROJ4 = "+proj=lcc +lat_1=39.71666666666667 +lat_2=40.78333333333333 +lat_0=39.33333333333334 +lon_0=-105.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Colorado South FIPS 0503"
p.PROJ4 = "+proj=lcc +lat_1=37.23333333333333 +lat_2=38.43333333333333 +lat_0=36.66666666666666 +lon_0=-105.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Connecticut FIPS 0600"
p.PROJ4 = "+proj=lcc +lat_1=41.2 +lat_2=41.86666666666667 +lat_0=40.83333333333334 +lon_0=-72.75 +x_0=182880.3657607315 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Delaware FIPS 0700"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=-75.41666666666667 +k=0.999995 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Florida East FIPS 0901"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-81 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Florida North FIPS 0903"
p.PROJ4 = "+proj=lcc +lat_1=29.58333333333333 +lat_2=30.75 +lat_0=29 +lon_0=-84.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Florida West FIPS 0902"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-82 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Georgia East FIPS 1001"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-82.16666666666667 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Georgia West FIPS 1002"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-84.16666666666667 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Guam FIPS 5400"
p.PROJ4 = "+proj=poly +lat_0=13.47246635277778 +lon_0=144.7487507055556 +x_0=50000.00000000002 +y_0=50000.00000000002 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Idaho Central FIPS 1102"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-114 +k=0.999947 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Idaho East FIPS 1101"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-112.1666666666667 +k=0.999947 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Idaho West FIPS 1103"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-115.75 +k=0.999933 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Illinois East FIPS 1201"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-88.33333333333333 +k=0.999975 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Illinois West FIPS 1202"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-90.16666666666667 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Indiana East FIPS 1301"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-85.66666666666667 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Indiana West FIPS 1302"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-87.08333333333333 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Iowa North FIPS 1401"
p.PROJ4 = "+proj=lcc +lat_1=42.06666666666667 +lat_2=43.26666666666667 +lat_0=41.5 +lon_0=-93.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Iowa South FIPS 1402"
p.PROJ4 = "+proj=lcc +lat_1=40.61666666666667 +lat_2=41.78333333333333 +lat_0=40 +lon_0=-93.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Kansas North FIPS 1501"
p.PROJ4 = "+proj=lcc +lat_1=38.71666666666667 +lat_2=39.78333333333333 +lat_0=38.33333333333334 +lon_0=-98 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Kansas South FIPS 1502"
p.PROJ4 = "+proj=lcc +lat_1=37.26666666666667 +lat_2=38.56666666666667 +lat_0=36.66666666666666 +lon_0=-98.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Kentucky North FIPS 1601"
p.PROJ4 = "+proj=lcc +lat_1=37.96666666666667 +lat_2=38.96666666666667 +lat_0=37.5 +lon_0=-84.25 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Kentucky South FIPS 1602"
p.PROJ4 = "+proj=lcc +lat_1=36.73333333333333 +lat_2=37.93333333333333 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Louisiana North FIPS 1701"
p.PROJ4 = "+proj=lcc +lat_1=31.16666666666667 +lat_2=32.66666666666666 +lat_0=30.66666666666667 +lon_0=-92.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Louisiana South FIPS 1702"
p.PROJ4 = "+proj=lcc +lat_1=29.3 +lat_2=30.7 +lat_0=28.66666666666667 +lon_0=-91.33333333333333 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Maine East FIPS 1801"
p.PROJ4 = "+proj=tmerc +lat_0=43.83333333333334 +lon_0=-68.5 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Maine West FIPS 1802"
p.PROJ4 = "+proj=tmerc +lat_0=42.83333333333334 +lon_0=-70.16666666666667 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Maryland FIPS 1900"
p.PROJ4 = "+proj=lcc +lat_1=38.3 +lat_2=39.45 +lat_0=37.83333333333334 +lon_0=-77 +x_0=243840.4876809754 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Massachusetts Island FIPS 2002"
p.PROJ4 = "+proj=lcc +lat_1=41.28333333333333 +lat_2=41.48333333333333 +lat_0=41 +lon_0=-70.5 +x_0=60960.12192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Massachusetts Mainland FIPS 2001"
p.PROJ4 = "+proj=lcc +lat_1=41.71666666666667 +lat_2=42.68333333333333 +lat_0=41 +lon_0=-71.5 +x_0=182880.3657607315 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Michigan Central FIPS 2112"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.33333333333333 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Michigan North FIPS 2111"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Michigan South FIPS 2113"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.33333333333333 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Minnesota Central FIPS 2202"
p.PROJ4 = "+proj=lcc +lat_1=45.61666666666667 +lat_2=47.05 +lat_0=45 +lon_0=-94.25 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Minnesota North FIPS 2201"
p.PROJ4 = "+proj=lcc +lat_1=47.03333333333333 +lat_2=48.63333333333333 +lat_0=46.5 +lon_0=-93.09999999999999 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Minnesota South FIPS 2203"
p.PROJ4 = "+proj=lcc +lat_1=43.78333333333333 +lat_2=45.21666666666667 +lat_0=43 +lon_0=-94 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Mississippi East FIPS 2301"
p.PROJ4 = "+proj=tmerc +lat_0=29.66666666666667 +lon_0=-88.83333333333333 +k=0.999960 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Mississippi West FIPS 2302"
p.PROJ4 = "+proj=tmerc +lat_0=30.5 +lon_0=-90.33333333333333 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Missouri Central FIPS 2402"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-92.5 +k=0.999933 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Missouri East FIPS 2401"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-90.5 +k=0.999933 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Missouri West FIPS 2403"
p.PROJ4 = "+proj=tmerc +lat_0=36.16666666666666 +lon_0=-94.5 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Montana Central FIPS 2502"
p.PROJ4 = "+proj=lcc +lat_1=46.45 +lat_2=47.88333333333333 +lat_0=45.83333333333334 +lon_0=-109.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Montana North FIPS 2501"
p.PROJ4 = "+proj=lcc +lat_1=47.85 +lat_2=48.71666666666667 +lat_0=47 +lon_0=-109.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Montana South FIPS 2503"
p.PROJ4 = "+proj=lcc +lat_1=44.86666666666667 +lat_2=46.4 +lat_0=44 +lon_0=-109.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Nebraska North FIPS 2601"
p.PROJ4 = "+proj=lcc +lat_1=41.85 +lat_2=42.81666666666667 +lat_0=41.33333333333334 +lon_0=-100 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Nebraska South FIPS 2602"
p.PROJ4 = "+proj=lcc +lat_1=40.28333333333333 +lat_2=41.71666666666667 +lat_0=39.66666666666666 +lon_0=-99.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Nevada Central FIPS 2702"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-116.6666666666667 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Nevada East FIPS 2701"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-115.5833333333333 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Nevada West FIPS 2703"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-118.5833333333333 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New Hampshire FIPS 2800"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-71.66666666666667 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New Jersey FIPS 2900"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.66666666666667 +k=0.999975 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New Mexico Central FIPS 3002"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-106.25 +k=0.999900 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New Mexico East FIPS 3001"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-104.3333333333333 +k=0.999909 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New Mexico West FIPS 3003"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-107.8333333333333 +k=0.999917 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New York Central FIPS 3102"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-76.58333333333333 +k=0.999938 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New York East FIPS 3101"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-74.33333333333333 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New York Long Island FIPS 3104"
p.PROJ4 = "+proj=lcc +lat_1=40.66666666666666 +lat_2=41.03333333333333 +lat_0=40.5 +lon_0=-74 +x_0=609601.2192024385 +y_0=30480.06096012193 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane New York West FIPS 3103"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-78.58333333333333 +k=0.999938 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane North Carolina FIPS 3200"
p.PROJ4 = "+proj=lcc +lat_1=34.33333333333334 +lat_2=36.16666666666666 +lat_0=33.75 +lon_0=-79 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane North Dakota North FIPS 3301"
p.PROJ4 = "+proj=lcc +lat_1=47.43333333333333 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-100.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane North Dakota South FIPS 3302"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=47.48333333333333 +lat_0=45.66666666666666 +lon_0=-100.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Ohio North FIPS 3401"
p.PROJ4 = "+proj=lcc +lat_1=40.43333333333333 +lat_2=41.7 +lat_0=39.66666666666666 +lon_0=-82.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Ohio South FIPS 3402"
p.PROJ4 = "+proj=lcc +lat_1=38.73333333333333 +lat_2=40.03333333333333 +lat_0=38 +lon_0=-82.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Oklahoma North FIPS 3501"
p.PROJ4 = "+proj=lcc +lat_1=35.56666666666667 +lat_2=36.76666666666667 +lat_0=35 +lon_0=-98 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Oklahoma South FIPS 3502"
p.PROJ4 = "+proj=lcc +lat_1=33.93333333333333 +lat_2=35.23333333333333 +lat_0=33.33333333333334 +lon_0=-98 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Oregon North FIPS 3601"
p.PROJ4 = "+proj=lcc +lat_1=44.33333333333334 +lat_2=46 +lat_0=43.66666666666666 +lon_0=-120.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Oregon South FIPS 3602"
p.PROJ4 = "+proj=lcc +lat_1=42.33333333333334 +lat_2=44 +lat_0=41.66666666666666 +lon_0=-120.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Pennsylvania North FIPS 3701"
p.PROJ4 = "+proj=lcc +lat_1=40.88333333333333 +lat_2=41.95 +lat_0=40.16666666666666 +lon_0=-77.75 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Pennsylvania South FIPS 3702"
p.PROJ4 = "+proj=lcc +lat_1=39.93333333333333 +lat_2=40.96666666666667 +lat_0=39.33333333333334 +lon_0=-77.75 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Puerto Rico FIPS 5201"
p.PROJ4 = "+proj=lcc +lat_1=18.03333333333333 +lat_2=18.43333333333333 +lat_0=17.83333333333333 +lon_0=-66.43333333333334 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Rhode Island FIPS 3800"
p.PROJ4 = "+proj=tmerc +lat_0=41.08333333333334 +lon_0=-71.5 +k=0.999994 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane South Carolina North FIPS 3901"
p.PROJ4 = "+proj=lcc +lat_1=33.76666666666667 +lat_2=34.96666666666667 +lat_0=33 +lon_0=-81 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane South Carolina South FIPS 3902"
p.PROJ4 = "+proj=lcc +lat_1=32.33333333333334 +lat_2=33.66666666666666 +lat_0=31.83333333333333 +lon_0=-81 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane South Dakota North FIPS 4001"
p.PROJ4 = "+proj=lcc +lat_1=44.41666666666666 +lat_2=45.68333333333333 +lat_0=43.83333333333334 +lon_0=-100 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane South Dakota South FIPS 4002"
p.PROJ4 = "+proj=lcc +lat_1=42.83333333333334 +lat_2=44.4 +lat_0=42.33333333333334 +lon_0=-100.3333333333333 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Tennessee FIPS 4100"
p.PROJ4 = "+proj=lcc +lat_1=35.25 +lat_2=36.41666666666666 +lat_0=34.66666666666666 +lon_0=-86 +x_0=609601.2192024385 +y_0=30480.06096012193 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Texas Central FIPS 4203"
p.PROJ4 = "+proj=lcc +lat_1=30.11666666666667 +lat_2=31.88333333333333 +lat_0=29.66666666666667 +lon_0=-100.3333333333333 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Texas North Central FIPS 4202"
p.PROJ4 = "+proj=lcc +lat_1=32.13333333333333 +lat_2=33.96666666666667 +lat_0=31.66666666666667 +lon_0=-97.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Texas North FIPS 4201"
p.PROJ4 = "+proj=lcc +lat_1=34.65 +lat_2=36.18333333333333 +lat_0=34 +lon_0=-101.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Texas South Central FIPS 4204"
p.PROJ4 = "+proj=lcc +lat_1=28.38333333333333 +lat_2=30.28333333333333 +lat_0=27.83333333333333 +lon_0=-99 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Texas South FIPS 4205"
p.PROJ4 = "+proj=lcc +lat_1=26.16666666666667 +lat_2=27.83333333333333 +lat_0=25.66666666666667 +lon_0=-98.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Utah Central FIPS 4302"
p.PROJ4 = "+proj=lcc +lat_1=39.01666666666667 +lat_2=40.65 +lat_0=38.33333333333334 +lon_0=-111.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Utah North FIPS 4301"
p.PROJ4 = "+proj=lcc +lat_1=40.71666666666667 +lat_2=41.78333333333333 +lat_0=40.33333333333334 +lon_0=-111.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Utah South FIPS 4303"
p.PROJ4 = "+proj=lcc +lat_1=37.21666666666667 +lat_2=38.35 +lat_0=36.66666666666666 +lon_0=-111.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Vermont FIPS 3400"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-72.5 +k=0.999964 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Virginia North FIPS 4501"
p.PROJ4 = "+proj=lcc +lat_1=38.03333333333333 +lat_2=39.2 +lat_0=37.66666666666666 +lon_0=-78.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Virginia South FIPS 4502"
p.PROJ4 = "+proj=lcc +lat_1=36.76666666666667 +lat_2=37.96666666666667 +lat_0=36.33333333333334 +lon_0=-78.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Washington North FIPS 4601"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-120.8333333333333 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Washington South FIPS 4602"
p.PROJ4 = "+proj=lcc +lat_1=45.83333333333334 +lat_2=47.33333333333334 +lat_0=45.33333333333334 +lon_0=-120.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane West Virginia North FIPS 4701"
p.PROJ4 = "+proj=lcc +lat_1=39 +lat_2=40.25 +lat_0=38.5 +lon_0=-79.5 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane West Virginia South FIPS 4702"
p.PROJ4 = "+proj=lcc +lat_1=37.48333333333333 +lat_2=38.88333333333333 +lat_0=37 +lon_0=-81 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wisconsin Central FIPS 4802"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=45.5 +lat_0=43.83333333333334 +lon_0=-90 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wisconsin North FIPS 4801"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=46.76666666666667 +lat_0=45.16666666666666 +lon_0=-90 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wisconsin South FIPS 4803"
p.PROJ4 = "+proj=lcc +lat_1=42.73333333333333 +lat_2=44.06666666666667 +lat_0=42 +lon_0=-90 +x_0=609601.2192024385 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wyoming East Central FIPS 4902"
p.PROJ4 = "+proj=tmerc +lat_0=40.66666666666666 +lon_0=-107.3333333333333 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wyoming East FIPS 4901"
p.PROJ4 = "+proj=tmerc +lat_0=40.66666666666666 +lon_0=-105.1666666666667 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wyoming West Central FIPS 4903"
p.PROJ4 = "+proj=tmerc +lat_0=40.66666666666666 +lon_0=-108.75 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1927"
p.Name = "NAD 1927 StatePlane Wyoming West FIPS 4904"
p.PROJ4 = "+proj=tmerc +lat_0=40.66666666666666 +lon_0=-110.0833333333333 +k=0.999941 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 Maine 2000 Central Zone"
p.PROJ4 = "+proj=tmerc +lat_0=43.5 +lon_0=-69.125 +k=0.999980 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 Maine 2000 East Zone"
p.PROJ4 = "+proj=tmerc +lat_0=43.83333333333334 +lon_0=-67.875 +k=0.999980 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 Maine 2000 West Zone"
p.PROJ4 = "+proj=tmerc +lat_0=42.83333333333334 +lon_0=-70.375 +k=0.999980 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alabama East FIPS 0101"
p.PROJ4 = "+proj=tmerc +lat_0=30.5 +lon_0=-85.83333333333333 +k=0.999960 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alabama West FIPS 0102"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-87.5 +k=0.999933 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 1 FIPS 5001"
p.PROJ4 = "+proj=omerc +lat_0=57 +lonc=-133.6666666666667 +alpha=-36.86989764583333 +k=0.9999 +x_0=5000000 +y_0=-5000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 10 FIPS 5010"
p.PROJ4 = "+proj=lcc +lat_1=51.83333333333334 +lat_2=53.83333333333334 +lat_0=51 +lon_0=-176 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 2 FIPS 5002"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-142 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 3 FIPS 5003"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-146 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 4 FIPS 5004"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-150 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 5 FIPS 5005"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-154 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 6 FIPS 5006"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-158 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 7 FIPS 5007"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-162 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 8 FIPS 5008"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-166 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Alaska 9 FIPS 5009"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-170 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Arizona Central FIPS 0202"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-111.9166666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Arizona East FIPS 0201"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-110.1666666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Arizona West FIPS 0203"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-113.75 +k=0.999933 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Arkansas North FIPS 0301"
p.PROJ4 = "+proj=lcc +lat_1=34.93333333333333 +lat_2=36.23333333333333 +lat_0=34.33333333333334 +lon_0=-92 +x_0=400000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Arkansas South FIPS 0302"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_2=34.76666666666667 +lat_0=32.66666666666666 +lon_0=-92 +x_0=400000 +y_0=400000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane California I FIPS 0401"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=41.66666666666666 +lat_0=39.33333333333334 +lon_0=-122 +x_0=2000000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane California II FIPS 0402"
p.PROJ4 = "+proj=lcc +lat_1=38.33333333333334 +lat_2=39.83333333333334 +lat_0=37.66666666666666 +lon_0=-122 +x_0=2000000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane California III FIPS 0403"
p.PROJ4 = "+proj=lcc +lat_1=37.06666666666667 +lat_2=38.43333333333333 +lat_0=36.5 +lon_0=-120.5 +x_0=2000000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane California IV FIPS 0404"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_2=37.25 +lat_0=35.33333333333334 +lon_0=-119 +x_0=2000000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane California V FIPS 0405"
p.PROJ4 = "+proj=lcc +lat_1=34.03333333333333 +lat_2=35.46666666666667 +lat_0=33.5 +lon_0=-118 +x_0=2000000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane California VI FIPS 0406"
p.PROJ4 = "+proj=lcc +lat_1=32.78333333333333 +lat_2=33.88333333333333 +lat_0=32.16666666666666 +lon_0=-116.25 +x_0=2000000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Colorado Central FIPS 0502"
p.PROJ4 = "+proj=lcc +lat_1=38.45 +lat_2=39.75 +lat_0=37.83333333333334 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Colorado North FIPS 0501"
p.PROJ4 = "+proj=lcc +lat_1=39.71666666666667 +lat_2=40.78333333333333 +lat_0=39.33333333333334 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Colorado South FIPS 0503"
p.PROJ4 = "+proj=lcc +lat_1=37.23333333333333 +lat_2=38.43333333333333 +lat_0=36.66666666666666 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Connecticut FIPS 0600"
p.PROJ4 = "+proj=lcc +lat_1=41.2 +lat_2=41.86666666666667 +lat_0=40.83333333333334 +lon_0=-72.75 +x_0=304800.6096 +y_0=152400.3048 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Delaware FIPS 0700"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=-75.41666666666667 +k=0.999995 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Florida East FIPS 0901"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-81 +k=0.999941 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Florida North FIPS 0903"
p.PROJ4 = "+proj=lcc +lat_1=29.58333333333333 +lat_2=30.75 +lat_0=29 +lon_0=-84.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Florida West FIPS 0902"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-82 +k=0.999941 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Georgia East FIPS 1001"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-82.16666666666667 +k=0.999900 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Georgia West FIPS 1002"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-84.16666666666667 +k=0.999900 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Guam FIPS 5400"
p.PROJ4 = "+proj=poly +lat_0=13.47246635277778 +lon_0=144.7487507055556 +x_0=50000 +y_0=50000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Hawaii 1 FIPS 5101"
p.PROJ4 = "+proj=tmerc +lat_0=18.83333333333333 +lon_0=-155.5 +k=0.999967 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Hawaii 2 FIPS 5102"
p.PROJ4 = "+proj=tmerc +lat_0=20.33333333333333 +lon_0=-156.6666666666667 +k=0.999967 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Hawaii 3 FIPS 5103"
p.PROJ4 = "+proj=tmerc +lat_0=21.16666666666667 +lon_0=-158 +k=0.999990 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Hawaii 4 FIPS 5104"
p.PROJ4 = "+proj=tmerc +lat_0=21.83333333333333 +lon_0=-159.5 +k=0.999990 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Hawaii 5 FIPS 5105"
p.PROJ4 = "+proj=tmerc +lat_0=21.66666666666667 +lon_0=-160.1666666666667 +k=1.000000 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Idaho Central FIPS 1102"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-114 +k=0.999947 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Idaho East FIPS 1101"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-112.1666666666667 +k=0.999947 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Idaho West FIPS 1103"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-115.75 +k=0.999933 +x_0=800000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Illinois East FIPS 1201"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-88.33333333333333 +k=0.999975 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Illinois West FIPS 1202"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-90.16666666666667 +k=0.999941 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Indiana East FIPS 1301"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-85.66666666666667 +k=0.999967 +x_0=100000 +y_0=250000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Indiana West FIPS 1302"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-87.08333333333333 +k=0.999967 +x_0=900000 +y_0=250000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Iowa North FIPS 1401"
p.PROJ4 = "+proj=lcc +lat_1=42.06666666666667 +lat_2=43.26666666666667 +lat_0=41.5 +lon_0=-93.5 +x_0=1500000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Iowa South FIPS 1402"
p.PROJ4 = "+proj=lcc +lat_1=40.61666666666667 +lat_2=41.78333333333333 +lat_0=40 +lon_0=-93.5 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Kansas North FIPS 1501"
p.PROJ4 = "+proj=lcc +lat_1=38.71666666666667 +lat_2=39.78333333333333 +lat_0=38.33333333333334 +lon_0=-98 +x_0=400000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Kansas South FIPS 1502"
p.PROJ4 = "+proj=lcc +lat_1=37.26666666666667 +lat_2=38.56666666666667 +lat_0=36.66666666666666 +lon_0=-98.5 +x_0=400000 +y_0=400000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Kentucky FIPS 1600"
p.PROJ4 = "+proj=lcc +lat_1=37.08333333333334 +lat_2=38.66666666666666 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=1500000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Kentucky North FIPS 1601"
p.PROJ4 = "+proj=lcc +lat_1=37.96666666666667 +lat_2=38.96666666666667 +lat_0=37.5 +lon_0=-84.25 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Kentucky South FIPS 1602"
p.PROJ4 = "+proj=lcc +lat_1=36.73333333333333 +lat_2=37.93333333333333 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=500000 +y_0=500000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Louisiana North FIPS 1701"
p.PROJ4 = "+proj=lcc +lat_1=31.16666666666667 +lat_2=32.66666666666666 +lat_0=30.5 +lon_0=-92.5 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Louisiana South FIPS 1702"
p.PROJ4 = "+proj=lcc +lat_1=29.3 +lat_2=30.7 +lat_0=28.5 +lon_0=-91.33333333333333 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Maine East FIPS 1801"
p.PROJ4 = "+proj=tmerc +lat_0=43.66666666666666 +lon_0=-68.5 +k=0.999900 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Maine West FIPS 1802"
p.PROJ4 = "+proj=tmerc +lat_0=42.83333333333334 +lon_0=-70.16666666666667 +k=0.999967 +x_0=900000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Maryland FIPS 1900"
p.PROJ4 = "+proj=lcc +lat_1=38.3 +lat_2=39.45 +lat_0=37.66666666666666 +lon_0=-77 +x_0=400000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Massachusetts Island FIPS 2002"
p.PROJ4 = "+proj=lcc +lat_1=41.28333333333333 +lat_2=41.48333333333333 +lat_0=41 +lon_0=-70.5 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Massachusetts Mainland FIPS 2001"
p.PROJ4 = "+proj=lcc +lat_1=41.71666666666667 +lat_2=42.68333333333333 +lat_0=41 +lon_0=-71.5 +x_0=200000 +y_0=750000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Michigan Central FIPS 2112"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.36666666666666 +x_0=6000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Michigan North FIPS 2111"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=8000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Michigan South FIPS 2113"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.36666666666666 +x_0=4000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Minnesota Central FIPS 2202"
p.PROJ4 = "+proj=lcc +lat_1=45.61666666666667 +lat_2=47.05 +lat_0=45 +lon_0=-94.25 +x_0=800000 +y_0=100000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Minnesota North FIPS 2201"
p.PROJ4 = "+proj=lcc +lat_1=47.03333333333333 +lat_2=48.63333333333333 +lat_0=46.5 +lon_0=-93.09999999999999 +x_0=800000 +y_0=100000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Minnesota South FIPS 2203"
p.PROJ4 = "+proj=lcc +lat_1=43.78333333333333 +lat_2=45.21666666666667 +lat_0=43 +lon_0=-94 +x_0=800000 +y_0=100000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Mississippi East FIPS 2301"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-88.83333333333333 +k=0.999950 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Mississippi West FIPS 2302"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-90.33333333333333 +k=0.999950 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Missouri Central FIPS 2402"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-92.5 +k=0.999933 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Missouri East FIPS 2401"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-90.5 +k=0.999933 +x_0=250000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Missouri West FIPS 2403"
p.PROJ4 = "+proj=tmerc +lat_0=36.16666666666666 +lon_0=-94.5 +k=0.999941 +x_0=850000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Montana FIPS 2500"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=49 +lat_0=44.25 +lon_0=-109.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Nebraska FIPS 2600"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=43 +lat_0=39.83333333333334 +lon_0=-100 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Nevada Central FIPS 2702"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-116.6666666666667 +k=0.999900 +x_0=500000 +y_0=6000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Nevada East FIPS 2701"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-115.5833333333333 +k=0.999900 +x_0=200000 +y_0=8000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Nevada West FIPS 2703"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-118.5833333333333 +k=0.999900 +x_0=800000 +y_0=4000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New Hampshire FIPS 2800"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-71.66666666666667 +k=0.999967 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New Jersey FIPS 2900"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New Mexico Central FIPS 3002"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-106.25 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New Mexico East FIPS 3001"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-104.3333333333333 +k=0.999909 +x_0=165000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New Mexico West FIPS 3003"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-107.8333333333333 +k=0.999917 +x_0=830000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New York Central FIPS 3102"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-76.58333333333333 +k=0.999938 +x_0=250000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New York East FIPS 3101"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New York Long Island FIPS 3104"
p.PROJ4 = "+proj=lcc +lat_1=40.66666666666666 +lat_2=41.03333333333333 +lat_0=40.16666666666666 +lon_0=-74 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane New York West FIPS 3103"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-78.58333333333333 +k=0.999938 +x_0=350000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane North Carolina FIPS 3200"
p.PROJ4 = "+proj=lcc +lat_1=34.33333333333334 +lat_2=36.16666666666666 +lat_0=33.75 +lon_0=-79 +x_0=609601.22 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane North Dakota North FIPS 3301"
p.PROJ4 = "+proj=lcc +lat_1=47.43333333333333 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane North Dakota South FIPS 3302"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=47.48333333333333 +lat_0=45.66666666666666 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Ohio North FIPS 3401"
p.PROJ4 = "+proj=lcc +lat_1=40.43333333333333 +lat_2=41.7 +lat_0=39.66666666666666 +lon_0=-82.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Ohio South FIPS 3402"
p.PROJ4 = "+proj=lcc +lat_1=38.73333333333333 +lat_2=40.03333333333333 +lat_0=38 +lon_0=-82.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Oklahoma North FIPS 3501"
p.PROJ4 = "+proj=lcc +lat_1=35.56666666666667 +lat_2=36.76666666666667 +lat_0=35 +lon_0=-98 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Oklahoma South FIPS 3502"
p.PROJ4 = "+proj=lcc +lat_1=33.93333333333333 +lat_2=35.23333333333333 +lat_0=33.33333333333334 +lon_0=-98 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Oregon North FIPS 3601"
p.PROJ4 = "+proj=lcc +lat_1=44.33333333333334 +lat_2=46 +lat_0=43.66666666666666 +lon_0=-120.5 +x_0=2500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Oregon South FIPS 3602"
p.PROJ4 = "+proj=lcc +lat_1=42.33333333333334 +lat_2=44 +lat_0=41.66666666666666 +lon_0=-120.5 +x_0=1500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Pennsylvania North FIPS 3701"
p.PROJ4 = "+proj=lcc +lat_1=40.88333333333333 +lat_2=41.95 +lat_0=40.16666666666666 +lon_0=-77.75 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Pennsylvania South FIPS 3702"
p.PROJ4 = "+proj=lcc +lat_1=39.93333333333333 +lat_2=40.96666666666667 +lat_0=39.33333333333334 +lon_0=-77.75 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Puerto Rico Virgin Islands FIPS 5200"
p.PROJ4 = "+proj=lcc +lat_1=18.03333333333333 +lat_2=18.43333333333333 +lat_0=17.83333333333333 +lon_0=-66.43333333333334 +x_0=200000 +y_0=200000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Rhode Island FIPS 3800"
p.PROJ4 = "+proj=tmerc +lat_0=41.08333333333334 +lon_0=-71.5 +k=0.999994 +x_0=100000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane South Carolina FIPS 3900"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_2=34.83333333333334 +lat_0=31.83333333333333 +lon_0=-81 +x_0=609600 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane South Dakota North FIPS 4001"
p.PROJ4 = "+proj=lcc +lat_1=44.41666666666666 +lat_2=45.68333333333333 +lat_0=43.83333333333334 +lon_0=-100 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane South Dakota South FIPS 4002"
p.PROJ4 = "+proj=lcc +lat_1=42.83333333333334 +lat_2=44.4 +lat_0=42.33333333333334 +lon_0=-100.3333333333333 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Tennessee FIPS 4100"
p.PROJ4 = "+proj=lcc +lat_1=35.25 +lat_2=36.41666666666666 +lat_0=34.33333333333334 +lon_0=-86 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Texas Central FIPS 4203"
p.PROJ4 = "+proj=lcc +lat_1=30.11666666666667 +lat_2=31.88333333333333 +lat_0=29.66666666666667 +lon_0=-100.3333333333333 +x_0=700000 +y_0=3000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Texas North Central FIPS 4202"
p.PROJ4 = "+proj=lcc +lat_1=32.13333333333333 +lat_2=33.96666666666667 +lat_0=31.66666666666667 +lon_0=-98.5 +x_0=600000 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Texas North FIPS 4201"
p.PROJ4 = "+proj=lcc +lat_1=34.65 +lat_2=36.18333333333333 +lat_0=34 +lon_0=-101.5 +x_0=200000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Texas South Central FIPS 4204"
p.PROJ4 = "+proj=lcc +lat_1=28.38333333333333 +lat_2=30.28333333333333 +lat_0=27.83333333333333 +lon_0=-99 +x_0=600000 +y_0=4000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Texas South FIPS 4205"
p.PROJ4 = "+proj=lcc +lat_1=26.16666666666667 +lat_2=27.83333333333333 +lat_0=25.66666666666667 +lon_0=-98.5 +x_0=300000 +y_0=5000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Utah Central FIPS 4302"
p.PROJ4 = "+proj=lcc +lat_1=39.01666666666667 +lat_2=40.65 +lat_0=38.33333333333334 +lon_0=-111.5 +x_0=500000 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Utah North FIPS 4301"
p.PROJ4 = "+proj=lcc +lat_1=40.71666666666667 +lat_2=41.78333333333333 +lat_0=40.33333333333334 +lon_0=-111.5 +x_0=500000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Utah South FIPS 4303"
p.PROJ4 = "+proj=lcc +lat_1=37.21666666666667 +lat_2=38.35 +lat_0=36.66666666666666 +lon_0=-111.5 +x_0=500000 +y_0=3000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Vermont FIPS 4400"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-72.5 +k=0.999964 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Virginia North FIPS 4501"
p.PROJ4 = "+proj=lcc +lat_1=38.03333333333333 +lat_2=39.2 +lat_0=37.66666666666666 +lon_0=-78.5 +x_0=3500000 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Virginia South FIPS 4502"
p.PROJ4 = "+proj=lcc +lat_1=36.76666666666667 +lat_2=37.96666666666667 +lat_0=36.33333333333334 +lon_0=-78.5 +x_0=3500000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Washington North FIPS 4601"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-120.8333333333333 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Washington South FIPS 4602"
p.PROJ4 = "+proj=lcc +lat_1=45.83333333333334 +lat_2=47.33333333333334 +lat_0=45.33333333333334 +lon_0=-120.5 +x_0=500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane West Virginia North FIPS 4701"
p.PROJ4 = "+proj=lcc +lat_1=39 +lat_2=40.25 +lat_0=38.5 +lon_0=-79.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane West Virginia South FIPS 4702"
p.PROJ4 = "+proj=lcc +lat_1=37.48333333333333 +lat_2=38.88333333333333 +lat_0=37 +lon_0=-81 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wisconsin Central FIPS 4802"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=45.5 +lat_0=43.83333333333334 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wisconsin North FIPS 4801"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=46.76666666666667 +lat_0=45.16666666666666 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wisconsin South FIPS 4803"
p.PROJ4 = "+proj=lcc +lat_1=42.73333333333333 +lat_2=44.06666666666667 +lat_0=42 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wyoming East Central FIPS 4902"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-107.3333333333333 +k=0.999938 +x_0=400000 +y_0=100000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wyoming East FIPS 4901"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-105.1666666666667 +k=0.999938 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wyoming West Central FIPS 4903"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-108.75 +k=0.999938 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983"
p.Name = "NAD 1983 StatePlane Wyoming West FIPS 4904"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-110.0833333333333 +k=0.999938 +x_0=800000 +y_0=100000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alabama East FIPS 0101 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=30.5 +lon_0=-85.83333333333333 +k=0.999960 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alabama West FIPS 0102 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-87.5 +k=0.999933 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 1 FIPS 5001 (Feet)"
p.PROJ4 = "+proj=omerc +lat_0=57 +lonc=-133.6666666666667 +alpha=-36.86989764583333 +k=0.9999 +x_0=4999999.999999999 +y_0=-4999999.999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 10 FIPS 5010 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=51.83333333333334 +lat_2=53.83333333333334 +lat_0=51 +lon_0=-176 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 2 FIPS 5002 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-142 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 3 FIPS 5003 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-146 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 4 FIPS 5004 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-150 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 5 FIPS 5005 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-154 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 6 FIPS 5006 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-158 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 7 FIPS 5007 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-162 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 8 FIPS 5008 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-166 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Alaska 9 FIPS 5009 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=54 +lon_0=-170 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Arizona Central FIPS 0202 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-111.9166666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Arizona East FIPS 0201 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-110.1666666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Arizona West FIPS 0203  (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-113.75 +k=0.999933 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Arkansas North FIPS 0301 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=34.93333333333333 +lat_2=36.23333333333333 +lat_0=34.33333333333334 +lon_0=-92 +x_0=399999.9999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Arkansas South FIPS 0302 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_2=34.76666666666667 +lat_0=32.66666666666666 +lon_0=-92 +x_0=399999.9999999999 +y_0=399999.9999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane California I FIPS 0401 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=41.66666666666666 +lat_0=39.33333333333334 +lon_0=-122 +x_0=2000000 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane California II FIPS 0402 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=38.33333333333334 +lat_2=39.83333333333334 +lat_0=37.66666666666666 +lon_0=-122 +x_0=2000000 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane California III FIPS 0403 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.06666666666667 +lat_2=38.43333333333333 +lat_0=36.5 +lon_0=-120.5 +x_0=2000000 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane California IV FIPS 0404 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_2=37.25 +lat_0=35.33333333333334 +lon_0=-119 +x_0=2000000 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane California V FIPS 0405 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=34.03333333333333 +lat_2=35.46666666666667 +lat_0=33.5 +lon_0=-118 +x_0=2000000 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane California VI FIPS 0406 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=32.78333333333333 +lat_2=33.88333333333333 +lat_0=32.16666666666666 +lon_0=-116.25 +x_0=2000000 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Colorado Central FIPS 0502 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=38.45 +lat_2=39.75 +lat_0=37.83333333333334 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Colorado North FIPS 0501 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=39.71666666666667 +lat_2=40.78333333333333 +lat_0=39.33333333333334 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Colorado South FIPS 0503 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.23333333333333 +lat_2=38.43333333333333 +lat_0=36.66666666666666 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Connecticut FIPS 0600 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=41.2 +lat_2=41.86666666666667 +lat_0=40.83333333333334 +lon_0=-72.75 +x_0=304800.6096 +y_0=152400.3048 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Delaware FIPS 0700 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=-75.41666666666667 +k=0.999995 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Florida East FIPS 0901 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-81 +k=0.999941 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Florida North FIPS 0903 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=29.58333333333333 +lat_2=30.75 +lat_0=29 +lon_0=-84.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Florida West FIPS 0902 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-82 +k=0.999941 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Georgia East FIPS 1001 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-82.16666666666667 +k=0.999900 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Georgia West FIPS 1002 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-84.16666666666667 +k=0.999900 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Guam FIPS 5400 (Feet)"
p.PROJ4 = "+proj=poly +lat_0=13.47246635277778 +lon_0=144.7487507055556 +x_0=49999.99999999999 +y_0=49999.99999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Hawaii 1 FIPS 5101 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=18.83333333333333 +lon_0=-155.5 +k=0.999967 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Hawaii 2 FIPS 5102 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=20.33333333333333 +lon_0=-156.6666666666667 +k=0.999967 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Hawaii 3 FIPS 5103 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=21.16666666666667 +lon_0=-158 +k=0.999990 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Hawaii 4 FIPS 5104 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=21.83333333333333 +lon_0=-159.5 +k=0.999990 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Hawaii 5 FIPS 5105 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=21.66666666666667 +lon_0=-160.1666666666667 +k=1.000000 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Idaho Central FIPS 1102 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-114 +k=0.999947 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Idaho East FIPS 1101 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-112.1666666666667 +k=0.999947 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Idaho West FIPS 1103 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-115.75 +k=0.999933 +x_0=799999.9999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Illinois East FIPS 1201 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-88.33333333333333 +k=0.999975 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Illinois West FIPS 1202 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-90.16666666666667 +k=0.999941 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Indiana East FIPS 1301 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-85.66666666666667 +k=0.999967 +x_0=100000 +y_0=250000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Indiana West FIPS 1302 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-87.08333333333333 +k=0.999967 +x_0=900000.0000000001 +y_0=250000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Iowa North FIPS 1401 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=42.06666666666667 +lat_2=43.26666666666667 +lat_0=41.5 +lon_0=-93.5 +x_0=1500000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Iowa South FIPS 1402 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40.61666666666667 +lat_2=41.78333333333333 +lat_0=40 +lon_0=-93.5 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Kansas North FIPS 1501 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=38.71666666666667 +lat_2=39.78333333333333 +lat_0=38.33333333333334 +lon_0=-98 +x_0=399999.9999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Kansas South FIPS 1502 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.26666666666667 +lat_2=38.56666666666667 +lat_0=36.66666666666666 +lon_0=-98.5 +x_0=399999.9999999999 +y_0=399999.9999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Kentucky FIPS 1600 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.08333333333334 +lat_2=38.66666666666666 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=1500000 +y_0=999999.9999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Kentucky North FIPS 1601 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.96666666666667 +lat_2=38.96666666666667 +lat_0=37.5 +lon_0=-84.25 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Kentucky South FIPS 1602 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=36.73333333333333 +lat_2=37.93333333333333 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=500000.0000000002 +y_0=500000.0000000002 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Louisiana North FIPS 1701 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=31.16666666666667 +lat_2=32.66666666666666 +lat_0=30.5 +lon_0=-92.5 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Louisiana South FIPS 1702 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=29.3 +lat_2=30.7 +lat_0=28.5 +lon_0=-91.33333333333333 +x_0=1000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Maine East FIPS 1801 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=43.66666666666666 +lon_0=-68.5 +k=0.999900 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Maine West FIPS 1802 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=42.83333333333334 +lon_0=-70.16666666666667 +k=0.999967 +x_0=900000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Maryland FIPS 1900 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=38.3 +lat_2=39.45 +lat_0=37.66666666666666 +lon_0=-77 +x_0=399999.9999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Massachusetts Island FIPS 2002 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=41.28333333333333 +lat_2=41.48333333333333 +lat_0=41 +lon_0=-70.5 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Massachusetts Mainland FIPS 2001 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=41.71666666666667 +lat_2=42.68333333333333 +lat_0=41 +lon_0=-71.5 +x_0=200000 +y_0=750000.0000000001 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Michigan Central FIPS 2112 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.36666666666666 +x_0=6000000.000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Michigan North FIPS 2111 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=7999999.999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Michigan South FIPS 2113 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.36666666666666 +x_0=4000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Minnesota Central FIPS 2202 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=45.61666666666667 +lat_2=47.05 +lat_0=45 +lon_0=-94.25 +x_0=799999.9999999999 +y_0=100000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Minnesota North FIPS 2201 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=47.03333333333333 +lat_2=48.63333333333333 +lat_0=46.5 +lon_0=-93.09999999999999 +x_0=799999.9999999999 +y_0=100000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Minnesota South FIPS 2203 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=43.78333333333333 +lat_2=45.21666666666667 +lat_0=43 +lon_0=-94 +x_0=799999.9999999999 +y_0=100000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Mississippi East FIPS 2301 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-88.83333333333333 +k=0.999950 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Mississippi West FIPS 2302 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-90.33333333333333 +k=0.999950 +x_0=700000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Missouri Central FIPS 2402 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-92.5 +k=0.999933 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Missouri East FIPS 2401 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-90.5 +k=0.999933 +x_0=250000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Missouri West FIPS 2403 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=36.16666666666666 +lon_0=-94.5 +k=0.999941 +x_0=850000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Montana FIPS 2500 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=49 +lat_0=44.25 +lon_0=-109.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Nebraska FIPS 2600 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=43 +lat_0=39.83333333333334 +lon_0=-100 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Nevada Central FIPS 2702 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-116.6666666666667 +k=0.999900 +x_0=500000.0000000002 +y_0=6000000.000000001 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Nevada East FIPS 2701 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-115.5833333333333 +k=0.999900 +x_0=200000 +y_0=7999999.999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Nevada West FIPS 2703 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-118.5833333333333 +k=0.999900 +x_0=799999.9999999999 +y_0=4000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New Hampshire FIPS 2800 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-71.66666666666667 +k=0.999967 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New Jersey FIPS 2900 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New Mexico Central FIPS 3002 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-106.25 +k=0.999900 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New Mexico East FIPS 3001 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-104.3333333333333 +k=0.999909 +x_0=165000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New Mexico West FIPS 3003 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-107.8333333333333 +k=0.999917 +x_0=829999.9999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New York Central FIPS 3102 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-76.58333333333333 +k=0.999938 +x_0=250000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New York East FIPS 3101 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New York Long Island FIPS 3104 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40.66666666666666 +lat_2=41.03333333333333 +lat_0=40.16666666666666 +lon_0=-74 +x_0=300000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane New York West FIPS 3103 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-78.58333333333333 +k=0.999938 +x_0=350000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane North Carolina FIPS 3200 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=34.33333333333334 +lat_2=36.16666666666666 +lat_0=33.75 +lon_0=-79 +x_0=609601.2199999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane North Dakota North FIPS 3301 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=47.43333333333333 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-100.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane North Dakota South FIPS 3302 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=47.48333333333333 +lat_0=45.66666666666666 +lon_0=-100.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Ohio North FIPS 3401 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40.43333333333333 +lat_2=41.7 +lat_0=39.66666666666666 +lon_0=-82.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Ohio South FIPS 3402 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=38.73333333333333 +lat_2=40.03333333333333 +lat_0=38 +lon_0=-82.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Oklahoma North FIPS 3501 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=35.56666666666667 +lat_2=36.76666666666667 +lat_0=35 +lon_0=-98 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Oklahoma South FIPS 3502 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=33.93333333333333 +lat_2=35.23333333333333 +lat_0=33.33333333333334 +lon_0=-98 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Oregon North FIPS 3601 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=44.33333333333334 +lat_2=46 +lat_0=43.66666666666666 +lon_0=-120.5 +x_0=2500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Oregon South FIPS 3602 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=42.33333333333334 +lat_2=44 +lat_0=41.66666666666666 +lon_0=-120.5 +x_0=1500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Pennsylvania North FIPS 3701 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40.88333333333333 +lat_2=41.95 +lat_0=40.16666666666666 +lon_0=-77.75 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Pennsylvania South FIPS 3702 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=39.93333333333333 +lat_2=40.96666666666667 +lat_0=39.33333333333334 +lon_0=-77.75 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane PR Virgin Islands FIPS 5200 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=18.03333333333333 +lat_2=18.43333333333333 +lat_0=17.83333333333333 +lon_0=-66.43333333333334 +x_0=199999.9999999999 +y_0=199999.9999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Rhode Island FIPS 3800 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=41.08333333333334 +lon_0=-71.5 +k=0.999994 +x_0=100000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane South Carolina FIPS 3900 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_2=34.83333333333334 +lat_0=31.83333333333333 +lon_0=-81 +x_0=609600.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane South Dakota North FIPS 4001 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=44.41666666666666 +lat_2=45.68333333333333 +lat_0=43.83333333333334 +lon_0=-100 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane South Dakota South FIPS 4002 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=42.83333333333334 +lat_2=44.4 +lat_0=42.33333333333334 +lon_0=-100.3333333333333 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Tennessee FIPS 4100 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=35.25 +lat_2=36.41666666666666 +lat_0=34.33333333333334 +lon_0=-86 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Texas Central FIPS 4203 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=30.11666666666667 +lat_2=31.88333333333333 +lat_0=29.66666666666667 +lon_0=-100.3333333333333 +x_0=700000 +y_0=3000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Texas North Central FIPS 4202 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=32.13333333333333 +lat_2=33.96666666666667 +lat_0=31.66666666666667 +lon_0=-98.5 +x_0=600000.0000000001 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Texas North FIPS 4201 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=34.65 +lat_2=36.18333333333333 +lat_0=34 +lon_0=-101.5 +x_0=200000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Texas South Central FIPS 4204 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=28.38333333333333 +lat_2=30.28333333333333 +lat_0=27.83333333333333 +lon_0=-99 +x_0=600000.0000000001 +y_0=4000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Texas South FIPS 4205 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=26.16666666666667 +lat_2=27.83333333333333 +lat_0=25.66666666666667 +lon_0=-98.5 +x_0=300000 +y_0=4999999.999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Utah Central FIPS 4302 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=39.01666666666667 +lat_2=40.65 +lat_0=38.33333333333334 +lon_0=-111.5 +x_0=500000.0000000002 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Utah North FIPS 4301 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=40.71666666666667 +lat_2=41.78333333333333 +lat_0=40.33333333333334 +lon_0=-111.5 +x_0=500000.0000000002 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Utah South FIPS 4303 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.21666666666667 +lat_2=38.35 +lat_0=36.66666666666666 +lon_0=-111.5 +x_0=500000.0000000002 +y_0=3000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Vermont FIPS 4400 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-72.5 +k=0.999964 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Virginia North FIPS 4501 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=38.03333333333333 +lat_2=39.2 +lat_0=37.66666666666666 +lon_0=-78.5 +x_0=3499999.999999999 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Virginia South FIPS 4502 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=36.76666666666667 +lat_2=37.96666666666667 +lat_0=36.33333333333334 +lon_0=-78.5 +x_0=3499999.999999999 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Washington North FIPS 4601 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-120.8333333333333 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Washington South FIPS 4602 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=45.83333333333334 +lat_2=47.33333333333334 +lat_0=45.33333333333334 +lon_0=-120.5 +x_0=500000.0000000002 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane West Virginia North FIPS 4701 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=39 +lat_2=40.25 +lat_0=38.5 +lon_0=-79.5 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane West Virginia South FIPS 4702 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=37.48333333333333 +lat_2=38.88333333333333 +lat_0=37 +lon_0=-81 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wisconsin Central FIPS 4802 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=45.5 +lat_0=43.83333333333334 +lon_0=-90 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wisconsin North FIPS 4801 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=46.76666666666667 +lat_0=45.16666666666666 +lon_0=-90 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wisconsin South FIPS 4803 (Feet)"
p.PROJ4 = "+proj=lcc +lat_1=42.73333333333333 +lat_2=44.06666666666667 +lat_0=42 +lon_0=-90 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wyoming East Central FIPS 4902 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-107.3333333333333 +k=0.999938 +x_0=399999.9999999999 +y_0=100000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wyoming East FIPS 4901 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-105.1666666666667 +k=0.999938 +x_0=200000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wyoming West Central FIPS 4903 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-108.75 +k=0.999938 +x_0=600000.0000000001 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Feet)"
p.Name = "NAD 1983 StatePlane Wyoming West FIPS 4904 (Feet)"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-110.0833333333333 +k=0.999938 +x_0=799999.9999999999 +y_0=100000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Arizona Central FIPS 0202 Feet Intl"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-111.9166666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Arizona East FIPS 0201 Feet Intl"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-110.1666666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Arizona West FIPS 0203 Feet Intl"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-113.75 +k=0.999933 +x_0=213360 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Michigan Central FIPS 2112 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.36666666666666 +x_0=6000000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Michigan North FIPS 2111 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=7999999.999999998 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Michigan South FIPS 2113 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.36666666666666 +x_0=3999999.999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Montana FIPS 2500 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=49 +lat_0=44.25 +lon_0=-109.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane North Dakota North FIPS 3301 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=47.43333333333333 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane North Dakota South FIPS 3302 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=47.48333333333333 +lat_0=45.66666666666666 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Oregon North FIPS 3601 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=44.33333333333334 +lat_2=46 +lat_0=43.66666666666666 +lon_0=-120.5 +x_0=2500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Oregon South FIPS 3602 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=42.33333333333334 +lat_2=44 +lat_0=41.66666666666666 +lon_0=-120.5 +x_0=1500000 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane South Carolina FIPS 3900 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=32.5 +lat_2=34.83333333333334 +lat_0=31.83333333333333 +lon_0=-81 +x_0=609600 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Utah Central FIPS 4302 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=39.01666666666667 +lat_2=40.65 +lat_0=38.33333333333334 +lon_0=-111.5 +x_0=499999.9999999998 +y_0=2000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Utah North FIPS 4301 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=40.71666666666667 +lat_2=41.78333333333333 +lat_0=40.33333333333334 +lon_0=-111.5 +x_0=499999.9999999998 +y_0=999999.9999999999 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 (Intl Feet)"
p.Name = "NAD 1983 StatePlane Utah South FIPS 4303 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=37.21666666666667 +lat_2=38.35 +lat_0=36.66666666666666 +lon_0=-111.5 +x_0=499999.9999999998 +y_0=3000000 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN Maine 2000 Central Zone"
p.PROJ4 = "+proj=tmerc +lat_0=43.5 +lon_0=-69.125 +k=0.999980 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN Maine 2000 East Zone"
p.PROJ4 = "+proj=tmerc +lat_0=43.83333333333334 +lon_0=-67.875 +k=0.999980 +x_0=700000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN Maine 2000 West Zone"
p.PROJ4 = "+proj=tmerc +lat_0=42.83333333333334 +lon_0=-70.375 +k=0.999980 +x_0=300000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Alabama East FIPS 0101"
p.PROJ4 = "+proj=tmerc +lat_0=30.5 +lon_0=-85.83333333333333 +k=0.999960 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Alabama West FIPS 0102"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-87.5 +k=0.999933 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Arizona Central FIPS 0202"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-111.9166666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Arizona East FIPS 0201"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-110.1666666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Arizona West FIPS 0203"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-113.75 +k=0.999933 +x_0=213360 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Arkansas North FIPS 0301"
p.PROJ4 = "+proj=lcc +lat_1=34.93333333333333 +lat_2=36.23333333333333 +lat_0=34.33333333333334 +lon_0=-92 +x_0=400000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Arkansas South FIPS 0302"
p.PROJ4 = "+proj=lcc +lat_1=33.3 +lat_2=34.76666666666667 +lat_0=32.66666666666666 +lon_0=-92 +x_0=400000 +y_0=400000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane California I FIPS 0401"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=41.66666666666666 +lat_0=39.33333333333334 +lon_0=-122 +x_0=2000000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane California II FIPS 0402"
p.PROJ4 = "+proj=lcc +lat_1=38.33333333333334 +lat_2=39.83333333333334 +lat_0=37.66666666666666 +lon_0=-122 +x_0=2000000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane California III FIPS 0403"
p.PROJ4 = "+proj=lcc +lat_1=37.06666666666667 +lat_2=38.43333333333333 +lat_0=36.5 +lon_0=-120.5 +x_0=2000000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane California IV FIPS 0404"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_2=37.25 +lat_0=35.33333333333334 +lon_0=-119 +x_0=2000000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane California V FIPS 0405"
p.PROJ4 = "+proj=lcc +lat_1=34.03333333333333 +lat_2=35.46666666666667 +lat_0=33.5 +lon_0=-118 +x_0=2000000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane California VI FIPS 0406"
p.PROJ4 = "+proj=lcc +lat_1=32.78333333333333 +lat_2=33.88333333333333 +lat_0=32.16666666666666 +lon_0=-116.25 +x_0=2000000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Colorado Central FIPS 0502"
p.PROJ4 = "+proj=lcc +lat_1=38.45 +lat_2=39.75 +lat_0=37.83333333333334 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Colorado North FIPS 0501"
p.PROJ4 = "+proj=lcc +lat_1=39.71666666666667 +lat_2=40.78333333333333 +lat_0=39.33333333333334 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Colorado South FIPS 0503"
p.PROJ4 = "+proj=lcc +lat_1=37.23333333333333 +lat_2=38.43333333333333 +lat_0=36.66666666666666 +lon_0=-105.5 +x_0=914401.8289 +y_0=304800.6096 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Connecticut FIPS 0600"
p.PROJ4 = "+proj=lcc +lat_1=41.2 +lat_2=41.86666666666667 +lat_0=40.83333333333334 +lon_0=-72.75 +x_0=304800.6096 +y_0=152400.3048 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Delaware FIPS 0700"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=-75.41666666666667 +k=0.999995 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Florida East FIPS 0901"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-81 +k=0.999941 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Florida North FIPS 0903"
p.PROJ4 = "+proj=lcc +lat_1=29.58333333333333 +lat_2=30.75 +lat_0=29 +lon_0=-84.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Florida West FIPS 0902"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-82 +k=0.999941 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Georgia East FIPS 1001"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-82.16666666666667 +k=0.999900 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Georgia West FIPS 1002"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-84.16666666666667 +k=0.999900 +x_0=700000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Hawaii 1 FIPS 5101"
p.PROJ4 = "+proj=tmerc +lat_0=18.83333333333333 +lon_0=-155.5 +k=0.999967 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Hawaii 2 FIPS 5102"
p.PROJ4 = "+proj=tmerc +lat_0=20.33333333333333 +lon_0=-156.6666666666667 +k=0.999967 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Hawaii 3 FIPS 5103"
p.PROJ4 = "+proj=tmerc +lat_0=21.16666666666667 +lon_0=-158 +k=0.999990 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Hawaii 4 FIPS 5104"
p.PROJ4 = "+proj=tmerc +lat_0=21.83333333333333 +lon_0=-159.5 +k=0.999990 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Hawaii 5 FIPS 5105"
p.PROJ4 = "+proj=tmerc +lat_0=21.66666666666667 +lon_0=-160.1666666666667 +k=1.000000 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Idaho Central FIPS 1102"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-114 +k=0.999947 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Idaho East FIPS 1101"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-112.1666666666667 +k=0.999947 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Idaho West FIPS 1103"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-115.75 +k=0.999933 +x_0=800000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Illinois East FIPS 1201"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-88.33333333333333 +k=0.999975 +x_0=300000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Illinois West FIPS 1202"
p.PROJ4 = "+proj=tmerc +lat_0=36.66666666666666 +lon_0=-90.16666666666667 +k=0.999941 +x_0=700000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Indiana East FIPS 1301"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-85.66666666666667 +k=0.999967 +x_0=100000 +y_0=250000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Indiana West FIPS 1302"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-87.08333333333333 +k=0.999967 +x_0=900000 +y_0=250000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Iowa North FIPS 1401"
p.PROJ4 = "+proj=lcc +lat_1=42.06666666666667 +lat_2=43.26666666666667 +lat_0=41.5 +lon_0=-93.5 +x_0=1500000 +y_0=1000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Iowa South FIPS 1402"
p.PROJ4 = "+proj=lcc +lat_1=40.61666666666667 +lat_2=41.78333333333333 +lat_0=40 +lon_0=-93.5 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Kansas North FIPS 1501"
p.PROJ4 = "+proj=lcc +lat_1=38.71666666666667 +lat_2=39.78333333333333 +lat_0=38.33333333333334 +lon_0=-98 +x_0=400000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Kansas South FIPS 1502"
p.PROJ4 = "+proj=lcc +lat_1=37.26666666666667 +lat_2=38.56666666666667 +lat_0=36.66666666666666 +lon_0=-98.5 +x_0=400000 +y_0=400000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Kentucky North FIPS 1601"
p.PROJ4 = "+proj=lcc +lat_1=37.96666666666667 +lat_2=38.96666666666667 +lat_0=37.5 +lon_0=-84.25 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Kentucky South FIPS 1602"
p.PROJ4 = "+proj=lcc +lat_1=36.73333333333333 +lat_2=37.93333333333333 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=500000 +y_0=500000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Louisiana North FIPS 1701"
p.PROJ4 = "+proj=lcc +lat_1=31.16666666666667 +lat_2=32.66666666666666 +lat_0=30.5 +lon_0=-92.5 +x_0=1000000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Louisiana South FIPS 1702"
p.PROJ4 = "+proj=lcc +lat_1=29.3 +lat_2=30.7 +lat_0=28.5 +lon_0=-91.33333333333333 +x_0=1000000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Maine East FIPS 1801"
p.PROJ4 = "+proj=tmerc +lat_0=43.66666666666666 +lon_0=-68.5 +k=0.999900 +x_0=300000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Maine West FIPS 1802"
p.PROJ4 = "+proj=tmerc +lat_0=42.83333333333334 +lon_0=-70.16666666666667 +k=0.999967 +x_0=900000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Maryland FIPS 1900"
p.PROJ4 = "+proj=lcc +lat_1=38.3 +lat_2=39.45 +lat_0=37.66666666666666 +lon_0=-77 +x_0=400000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Massachusetts Island FIPS 2002"
p.PROJ4 = "+proj=lcc +lat_1=41.28333333333333 +lat_2=41.48333333333333 +lat_0=41 +lon_0=-70.5 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Massachusetts Mainland FIPS 2001"
p.PROJ4 = "+proj=lcc +lat_1=41.71666666666667 +lat_2=42.68333333333333 +lat_0=41 +lon_0=-71.5 +x_0=200000 +y_0=750000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Michigan Central FIPS 2112"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.36666666666666 +x_0=6000000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Michigan North FIPS 2111"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=8000000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Michigan South FIPS 2113"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.36666666666666 +x_0=4000000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Minnesota Central FIPS 2202"
p.PROJ4 = "+proj=lcc +lat_1=45.61666666666667 +lat_2=47.05 +lat_0=45 +lon_0=-94.25 +x_0=800000 +y_0=100000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Minnesota North FIPS 2201"
p.PROJ4 = "+proj=lcc +lat_1=47.03333333333333 +lat_2=48.63333333333333 +lat_0=46.5 +lon_0=-93.09999999999999 +x_0=800000 +y_0=100000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Minnesota South FIPS 2203"
p.PROJ4 = "+proj=lcc +lat_1=43.78333333333333 +lat_2=45.21666666666667 +lat_0=43 +lon_0=-94 +x_0=800000 +y_0=100000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Mississippi East FIPS 2301"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-88.83333333333333 +k=0.999950 +x_0=300000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Mississippi West FIPS 2302"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-90.33333333333333 +k=0.999950 +x_0=700000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Missouri Central FIPS 2402"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-92.5 +k=0.999933 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Missouri East FIPS 2401"
p.PROJ4 = "+proj=tmerc +lat_0=35.83333333333334 +lon_0=-90.5 +k=0.999933 +x_0=250000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Missouri West FIPS 2403"
p.PROJ4 = "+proj=tmerc +lat_0=36.16666666666666 +lon_0=-94.5 +k=0.999941 +x_0=850000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Montana FIPS 2500"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=49 +lat_0=44.25 +lon_0=-109.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Nebraska FIPS 2600"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=43 +lat_0=39.83333333333334 +lon_0=-100 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Nevada Central FIPS 2702"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-116.6666666666667 +k=0.999900 +x_0=500000 +y_0=6000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Nevada East FIPS 2701"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-115.5833333333333 +k=0.999900 +x_0=200000 +y_0=8000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Nevada West FIPS 2703"
p.PROJ4 = "+proj=tmerc +lat_0=34.75 +lon_0=-118.5833333333333 +k=0.999900 +x_0=800000 +y_0=4000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New Hampshire FIPS 2800"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-71.66666666666667 +k=0.999967 +x_0=300000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New Jersey FIPS 2900"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New Mexico Central FIPS 3002"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-106.25 +k=0.999900 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New Mexico East FIPS 3001"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-104.3333333333333 +k=0.999909 +x_0=165000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New Mexico West FIPS 3003"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-107.8333333333333 +k=0.999917 +x_0=830000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New York Central FIPS 3102"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-76.58333333333333 +k=0.999938 +x_0=250000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New York East FIPS 3101"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New York Long Island FIPS 3104"
p.PROJ4 = "+proj=lcc +lat_1=40.66666666666666 +lat_2=41.03333333333333 +lat_0=40.16666666666666 +lon_0=-74 +x_0=300000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane New York West FIPS 3103"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-78.58333333333333 +k=0.999938 +x_0=350000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane North Dakota North FIPS 3301"
p.PROJ4 = "+proj=lcc +lat_1=47.43333333333333 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane North Dakota South FIPS 3302"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=47.48333333333333 +lat_0=45.66666666666666 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Ohio North FIPS 3401"
p.PROJ4 = "+proj=lcc +lat_1=40.43333333333333 +lat_2=41.7 +lat_0=39.66666666666666 +lon_0=-82.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Ohio South FIPS 3402"
p.PROJ4 = "+proj=lcc +lat_1=38.73333333333333 +lat_2=40.03333333333333 +lat_0=38 +lon_0=-82.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Oklahoma North FIPS 3501"
p.PROJ4 = "+proj=lcc +lat_1=35.56666666666667 +lat_2=36.76666666666667 +lat_0=35 +lon_0=-98 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Oklahoma South FIPS 3502"
p.PROJ4 = "+proj=lcc +lat_1=33.93333333333333 +lat_2=35.23333333333333 +lat_0=33.33333333333334 +lon_0=-98 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Oregon North FIPS 3601"
p.PROJ4 = "+proj=lcc +lat_1=44.33333333333334 +lat_2=46 +lat_0=43.66666666666666 +lon_0=-120.5 +x_0=2500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Oregon South FIPS 3602"
p.PROJ4 = "+proj=lcc +lat_1=42.33333333333334 +lat_2=44 +lat_0=41.66666666666666 +lon_0=-120.5 +x_0=1500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane PR Virgin Islands FIPS 5200"
p.PROJ4 = "+proj=lcc +lat_1=18.03333333333333 +lat_2=18.43333333333333 +lat_0=17.83333333333333 +lon_0=-66.43333333333334 +x_0=200000 +y_0=200000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Rhode Island FIPS 3800"
p.PROJ4 = "+proj=tmerc +lat_0=41.08333333333334 +lon_0=-71.5 +k=0.999994 +x_0=100000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane South Dakota North FIPS 4001"
p.PROJ4 = "+proj=lcc +lat_1=44.41666666666666 +lat_2=45.68333333333333 +lat_0=43.83333333333334 +lon_0=-100 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane South Dakota South FIPS 4002"
p.PROJ4 = "+proj=lcc +lat_1=42.83333333333334 +lat_2=44.4 +lat_0=42.33333333333334 +lon_0=-100.3333333333333 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Tennessee FIPS 4100"
p.PROJ4 = "+proj=lcc +lat_1=35.25 +lat_2=36.41666666666666 +lat_0=34.33333333333334 +lon_0=-86 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Texas Central FIPS 4203"
p.PROJ4 = "+proj=lcc +lat_1=30.11666666666667 +lat_2=31.88333333333333 +lat_0=29.66666666666667 +lon_0=-100.3333333333333 +x_0=700000 +y_0=3000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Texas North Central FIPS 4202"
p.PROJ4 = "+proj=lcc +lat_1=32.13333333333333 +lat_2=33.96666666666667 +lat_0=31.66666666666667 +lon_0=-98.5 +x_0=600000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Texas North FIPS 4201"
p.PROJ4 = "+proj=lcc +lat_1=34.65 +lat_2=36.18333333333333 +lat_0=34 +lon_0=-101.5 +x_0=200000 +y_0=1000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Texas South Central FIPS 4204"
p.PROJ4 = "+proj=lcc +lat_1=28.38333333333333 +lat_2=30.28333333333333 +lat_0=27.83333333333333 +lon_0=-99 +x_0=600000 +y_0=4000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Texas South FIPS 4205"
p.PROJ4 = "+proj=lcc +lat_1=26.16666666666667 +lat_2=27.83333333333333 +lat_0=25.66666666666667 +lon_0=-98.5 +x_0=300000 +y_0=5000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Utah Central FIPS 4302"
p.PROJ4 = "+proj=lcc +lat_1=39.01666666666667 +lat_2=40.65 +lat_0=38.33333333333334 +lon_0=-111.5 +x_0=500000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Utah North FIPS 4301"
p.PROJ4 = "+proj=lcc +lat_1=40.71666666666667 +lat_2=41.78333333333333 +lat_0=40.33333333333334 +lon_0=-111.5 +x_0=500000 +y_0=1000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Utah South FIPS 4303"
p.PROJ4 = "+proj=lcc +lat_1=37.21666666666667 +lat_2=38.35 +lat_0=36.66666666666666 +lon_0=-111.5 +x_0=500000 +y_0=3000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Vermont FIPS 4400"
p.PROJ4 = "+proj=tmerc +lat_0=42.5 +lon_0=-72.5 +k=0.999964 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Virginia North FIPS 4501"
p.PROJ4 = "+proj=lcc +lat_1=38.03333333333333 +lat_2=39.2 +lat_0=37.66666666666666 +lon_0=-78.5 +x_0=3500000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Virginia South FIPS 4502"
p.PROJ4 = "+proj=lcc +lat_1=36.76666666666667 +lat_2=37.96666666666667 +lat_0=36.33333333333334 +lon_0=-78.5 +x_0=3500000 +y_0=1000000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Washington North FIPS 4601"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-120.8333333333333 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Washington South FIPS 4602"
p.PROJ4 = "+proj=lcc +lat_1=45.83333333333334 +lat_2=47.33333333333334 +lat_0=45.33333333333334 +lon_0=-120.5 +x_0=500000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane West Virginia North FIPS 4701"
p.PROJ4 = "+proj=lcc +lat_1=39 +lat_2=40.25 +lat_0=38.5 +lon_0=-79.5 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane West Virginia South FIPS 4702"
p.PROJ4 = "+proj=lcc +lat_1=37.48333333333333 +lat_2=38.88333333333333 +lat_0=37 +lon_0=-81 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wisconsin Central FIPS 4802"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=45.5 +lat_0=43.83333333333334 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wisconsin North FIPS 4801"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=46.76666666666667 +lat_0=45.16666666666666 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wisconsin South FIPS 4803"
p.PROJ4 = "+proj=lcc +lat_1=42.73333333333333 +lat_2=44.06666666666667 +lat_0=42 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wyoming East FIPS 4901"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-105.1666666666667 +k=0.999938 +x_0=200000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wyoming EC FIPS 4902"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-107.3333333333333 +k=0.999938 +x_0=400000 +y_0=100000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wyoming WC FIPS 4903"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-108.75 +k=0.999938 +x_0=600000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Nad 1983 harn"
p.Name = "NAD 1983 HARN StatePlane Wyoming West FIPS 4904"
p.PROJ4 = "+proj=tmerc +lat_0=40.5 +lon_0=-110.0833333333333 +k=0.999938 +x_0=800000 +y_0=100000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Arizona Central FIPS 0202 Feet Intl"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-111.9166666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Arizona East FIPS 0201 Feet Intl"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-110.1666666666667 +k=0.999900 +x_0=213360 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Arizona West FIPS 0203 Feet Intl"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-113.75 +k=0.999933 +x_0=213360 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane California I FIPS 0401 Feet"
p.PROJ4 = "+proj=lcc +lat_1=40 +lat_2=41.66666666666666 +lat_0=39.33333333333334 +lon_0=-122 +x_0=2000000 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane California II FIPS 0402 Feet"
p.PROJ4 = "+proj=lcc +lat_1=38.33333333333334 +lat_2=39.83333333333334 +lat_0=37.66666666666666 +lon_0=-122 +x_0=2000000 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane California III FIPS 0403 Feet"
p.PROJ4 = "+proj=lcc +lat_1=37.06666666666667 +lat_2=38.43333333333333 +lat_0=36.5 +lon_0=-120.5 +x_0=2000000 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane California IV FIPS 0404 Feet"
p.PROJ4 = "+proj=lcc +lat_1=36 +lat_2=37.25 +lat_0=35.33333333333334 +lon_0=-119 +x_0=2000000 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane California V FIPS 0405 Feet"
p.PROJ4 = "+proj=lcc +lat_1=34.03333333333333 +lat_2=35.46666666666667 +lat_0=33.5 +lon_0=-118 +x_0=2000000 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane California VI FIPS 0406 Feet"
p.PROJ4 = "+proj=lcc +lat_1=32.78333333333333 +lat_2=33.88333333333333 +lat_0=32.16666666666666 +lon_0=-116.25 +x_0=2000000 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Colorado Central FIPS 0502 Feet"
p.PROJ4 = "+proj=lcc +lat_1=38.45 +lat_2=39.75 +lat_0=37.83333333333334 +lon_0=-105.5 +x_0=914401.8288999999 +y_0=304800.6096 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Colorado North FIPS 0501 Feet"
p.PROJ4 = "+proj=lcc +lat_1=39.71666666666667 +lat_2=40.78333333333333 +lat_0=39.33333333333334 +lon_0=-105.5 +x_0=914401.8288999999 +y_0=304800.6096 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Colorado South FIPS 0503 Feet"
p.PROJ4 = "+proj=lcc +lat_1=37.23333333333333 +lat_2=38.43333333333333 +lat_0=36.66666666666666 +lon_0=-105.5 +x_0=914401.8288999999 +y_0=304800.6096 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Connecticut FIPS 0600 Feet"
p.PROJ4 = "+proj=lcc +lat_1=41.2 +lat_2=41.86666666666667 +lat_0=40.83333333333334 +lon_0=-72.75 +x_0=304800.6096 +y_0=152400.3048 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Delaware FIPS 0700 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=38 +lon_0=-75.41666666666667 +k=0.999995 +x_0=199999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Florida East FIPS 0901 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-81 +k=0.999941 +x_0=199999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Florida North FIPS 0903 Feet"
p.PROJ4 = "+proj=lcc +lat_1=29.58333333333333 +lat_2=30.75 +lat_0=29 +lon_0=-84.5 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Florida West FIPS 0902 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=24.33333333333333 +lon_0=-82 +k=0.999941 +x_0=199999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Georgia East FIPS 1001 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-82.16666666666667 +k=0.999900 +x_0=199999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Georgia West FIPS 1002 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=30 +lon_0=-84.16666666666667 +k=0.999900 +x_0=699999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Hawaii 1 FIPS 5101 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=18.83333333333333 +lon_0=-155.5 +k=0.999967 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Hawaii 2 FIPS 5102 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=20.33333333333333 +lon_0=-156.6666666666667 +k=0.999967 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Hawaii 3 FIPS 5103 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=21.16666666666667 +lon_0=-158 +k=0.999990 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Hawaii 4 FIPS 5104 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=21.83333333333333 +lon_0=-159.5 +k=0.999990 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Hawaii 5 FIPS 5105 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=21.66666666666667 +lon_0=-160.1666666666667 +k=1.000000 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Idaho Central FIPS 1102 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-114 +k=0.999947 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Idaho East FIPS 1101 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-112.1666666666667 +k=0.999947 +x_0=199999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Idaho West FIPS 1103 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=41.66666666666666 +lon_0=-115.75 +k=0.999933 +x_0=799999.9999999998 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Indiana East FIPS 1301 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-85.66666666666667 +k=0.999967 +x_0=99999.99999999999 +y_0=250000 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Indiana West FIPS 1302 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=37.5 +lon_0=-87.08333333333333 +k=0.999967 +x_0=900000 +y_0=250000 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Kentucky North FIPS 1601 Feet"
p.PROJ4 = "+proj=lcc +lat_1=37.96666666666667 +lat_2=38.96666666666667 +lat_0=37.5 +lon_0=-84.25 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Kentucky South FIPS 1602 Feet"
p.PROJ4 = "+proj=lcc +lat_1=36.73333333333333 +lat_2=37.93333333333333 +lat_0=36.33333333333334 +lon_0=-85.75 +x_0=500000.0000000001 +y_0=500000.0000000001 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Maryland FIPS 1900 Feet"
p.PROJ4 = "+proj=lcc +lat_1=38.3 +lat_2=39.45 +lat_0=37.66666666666666 +lon_0=-77 +x_0=399999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Massachusetts Island FIPS 2002 Feet"
p.PROJ4 = "+proj=lcc +lat_1=41.28333333333333 +lat_2=41.48333333333333 +lat_0=41 +lon_0=-70.5 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Massachusetts Mainland FIPS 2001 Feet"
p.PROJ4 = "+proj=lcc +lat_1=41.71666666666667 +lat_2=42.68333333333333 +lat_0=41 +lon_0=-71.5 +x_0=199999.9999999999 +y_0=750000 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Michigan Central FIPS 2112 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.36666666666666 +x_0=6000000 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Michigan North FIPS 2111 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=7999999.999999998 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Michigan South FIPS 2113 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.36666666666666 +x_0=3999999.999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Mississippi East FIPS 2301 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-88.83333333333333 +k=0.999950 +x_0=300000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Mississippi West FIPS 2302 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=29.5 +lon_0=-90.33333333333333 +k=0.999950 +x_0=699999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Montana FIPS 2500 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=45 +lat_2=49 +lat_0=44.25 +lon_0=-109.5 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New Mexico Central FIPS 3002 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-106.25 +k=0.999900 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New Mexico East FIPS 3001 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-104.3333333333333 +k=0.999909 +x_0=165000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New Mexico West FIPS 3003 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=31 +lon_0=-107.8333333333333 +k=0.999917 +x_0=829999.9999999998 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New York Central FIPS 3102 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-76.58333333333333 +k=0.999938 +x_0=250000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New York East FIPS 3101 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=38.83333333333334 +lon_0=-74.5 +k=0.999900 +x_0=150000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New York Long Island FIPS 3104 Feet"
p.PROJ4 = "+proj=lcc +lat_1=40.66666666666666 +lat_2=41.03333333333333 +lat_0=40.16666666666666 +lon_0=-74 +x_0=300000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane New York West FIPS 3103 Feet"
p.PROJ4 = "+proj=tmerc +lat_0=40 +lon_0=-78.58333333333333 +k=0.999938 +x_0=350000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane North Dakota North FIPS 3301 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=47.43333333333333 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane North Dakota South FIPS 3302 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=46.18333333333333 +lat_2=47.48333333333333 +lat_0=45.66666666666666 +lon_0=-100.5 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Oklahoma North FIPS 3501 Feet"
p.PROJ4 = "+proj=lcc +lat_1=35.56666666666667 +lat_2=36.76666666666667 +lat_0=35 +lon_0=-98 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Oklahoma South FIPS 3502 Feet"
p.PROJ4 = "+proj=lcc +lat_1=33.93333333333333 +lat_2=35.23333333333333 +lat_0=33.33333333333334 +lon_0=-98 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Oregon North FIPS 3601 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=44.33333333333334 +lat_2=46 +lat_0=43.66666666666666 +lon_0=-120.5 +x_0=2500000 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Oregon South FIPS 3602 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=42.33333333333334 +lat_2=44 +lat_0=41.66666666666666 +lon_0=-120.5 +x_0=1500000 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Tennessee FIPS 4100 Feet"
p.PROJ4 = "+proj=lcc +lat_1=35.25 +lat_2=36.41666666666666 +lat_0=34.33333333333334 +lon_0=-86 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Texas Central FIPS 4203 Feet"
p.PROJ4 = "+proj=lcc +lat_1=30.11666666666667 +lat_2=31.88333333333333 +lat_0=29.66666666666667 +lon_0=-100.3333333333333 +x_0=699999.9999999999 +y_0=3000000 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Texas North Central FIPS 4202 Feet"
p.PROJ4 = "+proj=lcc +lat_1=32.13333333333333 +lat_2=33.96666666666667 +lat_0=31.66666666666667 +lon_0=-98.5 +x_0=600000 +y_0=2000000 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Texas North FIPS 4201 Feet"
p.PROJ4 = "+proj=lcc +lat_1=34.65 +lat_2=36.18333333333333 +lat_0=34 +lon_0=-101.5 +x_0=199999.9999999999 +y_0=999999.9999999999 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Texas South Central FIPS 4204 Feet"
p.PROJ4 = "+proj=lcc +lat_1=28.38333333333333 +lat_2=30.28333333333333 +lat_0=27.83333333333333 +lon_0=-99 +x_0=600000 +y_0=3999999.999999999 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Texas South FIPS 4205 Feet"
p.PROJ4 = "+proj=lcc +lat_1=26.16666666666667 +lat_2=27.83333333333333 +lat_0=25.66666666666667 +lon_0=-98.5 +x_0=300000 +y_0=4999999.999999998 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Utah Central FIPS 4302 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=39.01666666666667 +lat_2=40.65 +lat_0=38.33333333333334 +lon_0=-111.5 +x_0=499999.9999999998 +y_0=2000000 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Utah North FIPS 4301 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=40.71666666666667 +lat_2=41.78333333333333 +lat_0=40.33333333333334 +lon_0=-111.5 +x_0=499999.9999999998 +y_0=999999.9999999999 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Utah South FIPS 4303 Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=37.21666666666667 +lat_2=38.35 +lat_0=36.66666666666666 +lon_0=-111.5 +x_0=499999.9999999998 +y_0=3000000 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Virginia North FIPS 4501 Feet"
p.PROJ4 = "+proj=lcc +lat_1=38.03333333333333 +lat_2=39.2 +lat_0=37.66666666666666 +lon_0=-78.5 +x_0=3499999.999999998 +y_0=2000000 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Virginia South FIPS 4502 Feet"
p.PROJ4 = "+proj=lcc +lat_1=36.76666666666667 +lat_2=37.96666666666667 +lat_0=36.33333333333334 +lon_0=-78.5 +x_0=3499999.999999998 +y_0=999999.9999999999 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Washington North FIPS 4601 Feet"
p.PROJ4 = "+proj=lcc +lat_1=47.5 +lat_2=48.73333333333333 +lat_0=47 +lon_0=-120.8333333333333 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Washington South FIPS 4602 Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.83333333333334 +lat_2=47.33333333333334 +lat_0=45.33333333333334 +lon_0=-120.5 +x_0=500000.0000000001 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Wisconsin Central FIPS 4802 Feet"
p.PROJ4 = "+proj=lcc +lat_1=44.25 +lat_2=45.5 +lat_0=43.83333333333334 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Wisconsin North FIPS 4801 Feet"
p.PROJ4 = "+proj=lcc +lat_1=45.56666666666667 +lat_2=46.76666666666667 +lat_0=45.16666666666666 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - NAD 1983 HARN (Feet, Intl and US)"
p.Name = "NAD 1983 HARN StatePlane Wisconsin South FIPS 4803 Feet"
p.PROJ4 = "+proj=lcc +lat_1=42.73333333333333 +lat_2=44.06666666666667 +lat_0=42 +lon_0=-90 +x_0=600000 +y_0=0 +ellps=GRS80 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "American Samoa 1962 StatePlane American Samoa FIPS 5300"
p.PROJ4 = "+proj=lcc +lat_1=-14.26666666666667 +lat_0=-14.26666666666667 +lon_0=-170 +k_0=1 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD 1983 HARN Guam Map Grid"
p.PROJ4 = "+proj=tmerc +lat_0=13.5 +lon_0=144.75 +k=1.000000 +x_0=100000 +y_0=200000 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 2S"
p.PROJ4 = "+proj=utm +zone=2 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD Michigan StatePlane Michigan Central FIPS 2112"
p.PROJ4 = "+proj=lcc +lat_1=44.18333333333333 +lat_2=45.7 +lat_0=43.31666666666667 +lon_0=-84.33333333333333 +x_0=609601.2192024385 +y_0=0 +a=6378450.047 +b=6356826.620025999 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD Michigan StatePlane Michigan Central Old FIPS 2102"
p.PROJ4 = "+proj=tmerc +lat_0=41.5 +lon_0=-85.75 +k=0.999909 +x_0=152400.3048006096 +y_0=0 +a=6378450.047 +b=6356826.620025999 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD Michigan StatePlane Michigan East Old FIPS 2101"
p.PROJ4 = "+proj=tmerc +lat_0=41.5 +lon_0=-83.66666666666667 +k=0.999943 +x_0=152400.3048006096 +y_0=0 +a=6378450.047 +b=6356826.620025999 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD Michigan StatePlane Michigan North FIPS 2111"
p.PROJ4 = "+proj=lcc +lat_1=45.48333333333333 +lat_2=47.08333333333334 +lat_0=44.78333333333333 +lon_0=-87 +x_0=609601.2192024385 +y_0=0 +a=6378450.047 +b=6356826.620025999 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD Michigan StatePlane Michigan South FIPS 2113"
p.PROJ4 = "+proj=lcc +lat_1=42.1 +lat_2=43.66666666666666 +lat_0=41.5 +lon_0=-84.33333333333333 +x_0=609601.2192024385 +y_0=0 +a=6378450.047 +b=6356826.620025999 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "NAD Michigan StatePlane Michigan West Old FIPS 2103"
p.PROJ4 = "+proj=tmerc +lat_0=41.5 +lon_0=-88.75 +k=0.999909 +x_0=152400.3048006096 +y_0=0 +a=6378450.047 +b=6356826.620025999 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Old Hawaiian StatePlane Hawaii 1 FIPS 5101"
p.PROJ4 = "+proj=tmerc +lat_0=18.83333333333333 +lon_0=-155.5 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Old Hawaiian StatePlane Hawaii 2 FIPS 5102"
p.PROJ4 = "+proj=tmerc +lat_0=20.33333333333333 +lon_0=-156.6666666666667 +k=0.999967 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Old Hawaiian StatePlane Hawaii 3 FIPS 5103"
p.PROJ4 = "+proj=tmerc +lat_0=21.16666666666667 +lon_0=-158 +k=0.999990 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Old Hawaiian StatePlane Hawaii 4 FIPS 5104"
p.PROJ4 = "+proj=tmerc +lat_0=21.83333333333333 +lon_0=-159.5 +k=0.999990 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Old Hawaiian StatePlane Hawaii 5 FIPS 5105"
p.PROJ4 = "+proj=tmerc +lat_0=21.66666666666667 +lon_0=-160.1666666666667 +k=1.000000 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Puerto Rico StatePlane Puerto Rico FIPS 5201"
p.PROJ4 = "+proj=lcc +lat_1=18.03333333333333 +lat_2=18.43333333333333 +lat_0=17.83333333333333 +lon_0=-66.43333333333334 +x_0=152400.3048006096 +y_0=0 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Plane - Other GCS"
p.Name = "Puerto Rico StatePlane Virgin Islands St Croix FIPS 5202"
p.PROJ4 = "+proj=lcc +lat_1=18.03333333333333 +lat_2=18.43333333333333 +lat_0=17.83333333333333 +lon_0=-66.43333333333334 +x_0=152400.3048006096 +y_0=30480.06096012193 +ellps=clrk66 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1927 Alaska Albers Feet"
p.PROJ4 = "+proj=aea +lat_1=55 +lat_2=65 +lat_0=50 +lon_0=-154 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1927 Alaska Albers Meters"
p.PROJ4 = "+proj=aea +lat_1=55 +lat_2=65 +lat_0=50 +lon_0=-154 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1927 California (Teale) Albers"
p.PROJ4 = "+proj=aea +lat_1=34 +lat_2=40.5 +lat_0=0 +lon_0=-120 +x_0=0 +y_0=-4000000 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1927 Georgia Statewide Albers"
p.PROJ4 = "+proj=aea +lat_1=29.5 +lat_2=45.5 +lat_0=23 +lon_0=-83.5 +x_0=0 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1927 Texas Statewide Mapping System"
p.PROJ4 = "+proj=lcc +lat_1=27.41666666666667 +lat_2=34.91666666666666 +lat_0=31.16666666666667 +lon_0=-100 +x_0=914400 +y_0=914400 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 California (Teale) Albers"
p.PROJ4 = "+proj=aea +lat_1=34 +lat_2=40.5 +lat_0=0 +lon_0=-120 +x_0=0 +y_0=-4000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Georgia Statewide Lambert"
p.PROJ4 = "+proj=lcc +lat_1=31.41666666666667 +lat_2=34.28333333333333 +lat_0=0 +lon_0=-83.5 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 HARN Oregon Statewide Lambert Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=43 +lat_2=45.5 +lat_0=41.75 +lon_0=-120.5 +x_0=399999.9999999999 +y_0=0 +ellps=GRS80 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 HARN Oregon Statewide Lambert"
p.PROJ4 = "+proj=lcc +lat_1=43 +lat_2=45.5 +lat_0=41.75 +lon_0=-120.5 +x_0=400000 +y_0=0 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Idaho TM"
p.PROJ4 = "+proj=tmerc +lat_0=42 +lon_0=-114 +k=0.999600 +x_0=2000000 +y_0=3000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Oregon Statewide Lambert Feet Intl"
p.PROJ4 = "+proj=lcc +lat_1=43 +lat_2=45.5 +lat_0=41.75 +lon_0=-120.5 +x_0=399999.9999999999 +y_0=0 +ellps=GRS80 +datum=NAD83 +to_meter=0.3048 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Oregon Statewide Lambert"
p.PROJ4 = "+proj=lcc +lat_1=43 +lat_2=45.5 +lat_0=41.75 +lon_0=-120.5 +x_0=400000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Texas Centric Mapping System Albers"
p.PROJ4 = "+proj=aea +lat_1=27.5 +lat_2=35 +lat_0=18 +lon_0=-100 +x_0=1500000 +y_0=6000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Texas Centric Mapping System Lambert"
p.PROJ4 = "+proj=lcc +lat_1=27.5 +lat_2=35 +lat_0=18 +lon_0=-100 +x_0=1500000 +y_0=5000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "State Systems"
p.Name = "NAD 1983 Texas Statewide Mapping System"
p.PROJ4 = "+proj=lcc +lat_1=27.41666666666667 +lat_2=34.91666666666666 +lat_0=31.16666666666667 +lon_0=-100 +x_0=1000000 +y_0=1000000 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
        ProjectionList.Add(p)

        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo16"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=16 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo17"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=17 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo18"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=18 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo19"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=19 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo20"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=20 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo21"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=21 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo22"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=22 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo23"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=23 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo24"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=24 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo25"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=25 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo26"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=26 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo27"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=27 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo28"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=28 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo29"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=29 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo30"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=30 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo31"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=31 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo32"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=32 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Projected Coordinate Systems"
        p.Category = "Transverse Mercator"
        p.Name = "WGS 1984 lo33"
        p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=33 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 10N"
p.PROJ4 = "+proj=utm +zone=10 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 11N"
p.PROJ4 = "+proj=utm +zone=11 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 12N"
p.PROJ4 = "+proj=utm +zone=12 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 13N"
p.PROJ4 = "+proj=utm +zone=13 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 14N"
p.PROJ4 = "+proj=utm +zone=14 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 15N"
p.PROJ4 = "+proj=utm +zone=15 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 16N"
p.PROJ4 = "+proj=utm +zone=16 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 1N"
p.PROJ4 = "+proj=utm +zone=1 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 2N"
p.PROJ4 = "+proj=utm +zone=2 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 3N"
p.PROJ4 = "+proj=utm +zone=3 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 4N"
p.PROJ4 = "+proj=utm +zone=4 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 59N"
p.PROJ4 = "+proj=utm +zone=59 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 5N"
p.PROJ4 = "+proj=utm +zone=5 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 60N"
p.PROJ4 = "+proj=utm +zone=60 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 6N"
p.PROJ4 = "+proj=utm +zone=6 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 7N"
p.PROJ4 = "+proj=utm +zone=7 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 8N"
p.PROJ4 = "+proj=utm +zone=8 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1927"
p.Name = "NAD 1927 UTM Zone 9N"
p.PROJ4 = "+proj=utm +zone=9 +ellps=clrk66 +datum=NAD27 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 10N"
p.PROJ4 = "+proj=utm +zone=10 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 11N"
p.PROJ4 = "+proj=utm +zone=11 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 12N"
p.PROJ4 = "+proj=utm +zone=12 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 13N"
p.PROJ4 = "+proj=utm +zone=13 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 14N"
p.PROJ4 = "+proj=utm +zone=14 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 15N"
p.PROJ4 = "+proj=utm +zone=15 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 16N"
p.PROJ4 = "+proj=utm +zone=16 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 1N"
p.PROJ4 = "+proj=utm +zone=1 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 23N"
p.PROJ4 = "+proj=utm +zone=23 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 2N"
p.PROJ4 = "+proj=utm +zone=2 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 3N"
p.PROJ4 = "+proj=utm +zone=3 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 4N"
p.PROJ4 = "+proj=utm +zone=4 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 59N"
p.PROJ4 = "+proj=utm +zone=59 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 5N"
p.PROJ4 = "+proj=utm +zone=5 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 60N"
p.PROJ4 = "+proj=utm +zone=60 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 6N"
p.PROJ4 = "+proj=utm +zone=6 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 7N"
p.PROJ4 = "+proj=utm +zone=7 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 8N"
p.PROJ4 = "+proj=utm +zone=8 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Nad 1983"
p.Name = "NAD 1983 UTM Zone 9N"
p.PROJ4 = "+proj=utm +zone=9 +ellps=GRS80 +datum=NAD83 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Abidjan 1987 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Abidjan 1987 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Adindan UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Adindan UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Afgooye UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Afgooye UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=krass +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Ain el Abd 1970 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Ain el Abd 1970 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Ain el Abd 1970 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "American Samoa 1962 UTM Zone 2S"
p.PROJ4 = "+proj=utm +zone=2 +south +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Aratu UTM Zone 22S"
p.PROJ4 = "+proj=utm +zone=22 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Aratu UTM Zone 23S"
p.PROJ4 = "+proj=utm +zone=23 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Aratu UTM Zone 24S"
p.PROJ4 = "+proj=utm +zone=24 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1950 UTM Zone 34S"
p.PROJ4 = "+proj=utm +zone=34 +south +a=6378249.145 +b=6356514.966395495 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1950 UTM Zone 35S"
p.PROJ4 = "+proj=utm +zone=35 +south +a=6378249.145 +b=6356514.966395495 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1950 UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +a=6378249.145 +b=6356514.966395495 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1960 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1960 UTM Zone 35S"
p.PROJ4 = "+proj=utm +zone=35 +south +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1960 UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1960 UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1960 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Arc 1960 UTM Zone 37S"
p.PROJ4 = "+proj=utm +zone=37 +south +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ATS 1977 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +a=6378135 +b=6356750.304921594 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ATS 1977 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +a=6378135 +b=6356750.304921594 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Azores Central 1995 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Azores Oriental 1995 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Batavia UTM Zone 48S"
p.PROJ4 = "+proj=utm +zone=48 +south +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Batavia UTM Zone 49S"
p.PROJ4 = "+proj=utm +zone=49 +south +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Batavia UTM Zone 50S"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Bissau UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Bogota UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Bogota UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Camacupa UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Camacupa UTM Zone 33S"
p.PROJ4 = "+proj=utm +zone=33 +south +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Campo Inchauspe UTM 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Campo Inchauspe UTM 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Cape UTM Zone 34S"
p.PROJ4 = "+proj=utm +zone=34 +south +a=6378249.145 +b=6356514.966395495 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Cape UTM Zone 35S"
p.PROJ4 = "+proj=utm +zone=35 +south +a=6378249.145 +b=6356514.966395495 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Cape UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +a=6378249.145 +b=6356514.966395495 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Carthage UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Combani 1950 UTM Zone 38S"
p.PROJ4 = "+proj=utm +zone=38 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Conakry 1905 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Conakry 1905 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Corrego Alegre UTM Zone 23S"
p.PROJ4 = "+proj=utm +zone=23 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Corrego Alegre UTM Zone 24S"
p.PROJ4 = "+proj=utm +zone=24 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "CSG 1967 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Dabola UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Dabola UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Datum 73 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Douala UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ED 1950 ED77 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ED 1950 ED77 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ED 1950 ED77 UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ED 1950 ED77 UTM Zone 41N"
p.PROJ4 = "+proj=utm +zone=41 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ELD 1979 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ELD 1979 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ELD 1979 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ELD 1979 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRF 1989 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 27N"
p.PROJ4 = "+proj=utm +zone=27 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ETRS 1989 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "European Datum 1950 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Fahud UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Fahud UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Fort Desaix UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Fort Marigot UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Garoua UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Graciosa Base SW 1948 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Grand Comoros UTM Zone 38S"
p.PROJ4 = "+proj=utm +zone=38 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Hito XVIII 1963 UTM Zone 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Hjorsey 1955 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Hjorsey 1955 UTM Zone 27N"
p.PROJ4 = "+proj=utm +zone=27 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Hjorsey 1955 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Hong Kong 1980 UTM Zone 49N"
p.PROJ4 = "+proj=utm +zone=49 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Hong Kong 1980 UTM Zone 50N"
p.PROJ4 = "+proj=utm +zone=50 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IGM 1995 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IGM 1995 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IGN53 Mare UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IGN56 Lifou UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IGN72 Grande Terre UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IGN72 Nuku Hiva UTM Zone 7S"
p.PROJ4 = "+proj=utm +zone=7 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1954 UTM Zone 46N"
p.PROJ4 = "+proj=utm +zone=46 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1954 UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1954 UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1960 UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1960 UTM Zone 49N"
p.PROJ4 = "+proj=utm +zone=49 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1975 UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indian 1975 UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +a=6377276.345 +b=6356075.41314024 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 46N"
p.PROJ4 = "+proj=utm +zone=46 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 46S"
p.PROJ4 = "+proj=utm +zone=46 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 47S"
p.PROJ4 = "+proj=utm +zone=47 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 48S"
p.PROJ4 = "+proj=utm +zone=48 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 49N"
p.PROJ4 = "+proj=utm +zone=49 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 49S"
p.PROJ4 = "+proj=utm +zone=49 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 50N"
p.PROJ4 = "+proj=utm +zone=50 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 50S"
p.PROJ4 = "+proj=utm +zone=50 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 51N"
p.PROJ4 = "+proj=utm +zone=51 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 51S"
p.PROJ4 = "+proj=utm +zone=51 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 52N"
p.PROJ4 = "+proj=utm +zone=52 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 52S"
p.PROJ4 = "+proj=utm +zone=52 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 53N"
p.PROJ4 = "+proj=utm +zone=53 +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 53S"
p.PROJ4 = "+proj=utm +zone=53 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Indonesia 1974 UTM Zone 54S"
p.PROJ4 = "+proj=utm +zone=54 +south +a=6378160 +b=6356774.50408554 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "IRENET95 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "JGD 2000 UTM Zone 51N"
p.PROJ4 = "+proj=utm +zone=51 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "JGD 2000 UTM Zone 52N"
p.PROJ4 = "+proj=utm +zone=52 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "JGD 2000 UTM Zone 53N"
p.PROJ4 = "+proj=utm +zone=53 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "JGD 2000 UTM Zone 54N"
p.PROJ4 = "+proj=utm +zone=54 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "JGD 2000 UTM Zone 55N"
p.PROJ4 = "+proj=utm +zone=55 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "JGD 2000 UTM Zone 56N"
p.PROJ4 = "+proj=utm +zone=56 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "K0 1949 UTM Zone 42S"
p.PROJ4 = "+proj=utm +zone=42 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Kertau UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +a=6377304.063 +b=6356103.038993155 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Kertau UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +a=6377304.063 +b=6356103.038993155 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Kousseri UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "La Canoa UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "La Canoa UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "La Canoa UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "La Canoa UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Locodjo 1965 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Locodjo 1965 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Lome UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "M'poraloko UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "M'poraloko UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Malongo 1987 UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Manoca 1962 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Massawa UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Mhast UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Minna UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Minna UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "MOP78 UTM Zone 1S"
p.PROJ4 = "+proj=utm +zone=1 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Moznet UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Moznet UTM Zone 37S"
p.PROJ4 = "+proj=utm +zone=37 +south +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1927 BLM Zone 14N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-99 +k=0.999600 +x_0=500000.0000000002 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1927 BLM Zone 15N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-93 +k=0.999600 +x_0=500000.0000000002 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1927 BLM Zone 16N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-87 +k=0.999600 +x_0=500000.0000000002 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1927 BLM Zone 17N"
p.PROJ4 = "+proj=tmerc +lat_0=0 +lon_0=-81 +k=0.999600 +x_0=500000.0000000002 +y_0=0 +ellps=clrk66 +datum=NAD27 +to_meter=0.3048006096012192 +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 11N"
p.PROJ4 = "+proj=utm +zone=11 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 12N"
p.PROJ4 = "+proj=utm +zone=12 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 13N"
p.PROJ4 = "+proj=utm +zone=13 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 2S"
p.PROJ4 = "+proj=utm +zone=2 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 4N"
p.PROJ4 = "+proj=utm +zone=4 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NAD 1983 HARN UTM Zone 5N"
p.PROJ4 = "+proj=utm +zone=5 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nahrwan 1967 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nahrwan 1967 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nahrwan 1967 UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Naparima 1955 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Naparima 1972 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NEA74 Noumea UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NGN UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NGN UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NGO 1948 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NGO 1948 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NGO 1948 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NGO 1948 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +a=6377492.018 +b=6356173.508712696 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nord Sahara 1959 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nord Sahara 1959 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nord Sahara 1959 UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Nord Sahara 1959 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NZGD 1949 UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NZGD 1949 UTM Zone 59S"
p.PROJ4 = "+proj=utm +zone=59 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NZGD 1949 UTM Zone 60S"
p.PROJ4 = "+proj=utm +zone=60 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NZGD 2000 UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NZGD 2000 UTM Zone 59S"
p.PROJ4 = "+proj=utm +zone=59 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "NZGD 2000 UTM Zone 60S"
p.PROJ4 = "+proj=utm +zone=60 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Observ Meteorologico 1939 UTM Zone 25N"
p.PROJ4 = "+proj=utm +zone=25 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Old Hawaiian UTM Zone 4N"
p.PROJ4 = "+proj=utm +zone=4 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Old Hawaiian UTM Zone 5N"
p.PROJ4 = "+proj=utm +zone=5 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "PDO 1993 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "PDO 1993 UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Pointe Noire UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Porto Santo 1936 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Porto Santo 1995 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 17s"
p.PROJ4 = "+proj=utm +zone=17 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 18S"
p.PROJ4 = "+proj=utm +zone=18 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Prov. S. Amer. Datum UTM Zone 22S"
p.PROJ4 = "+proj=utm +zone=22 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Puerto Rico UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Qornoq 1927 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Qornoq 1927 UTM Zone 23N"
p.PROJ4 = "+proj=utm +zone=23 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "REGVEN UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "REGVEN UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "REGVEN UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "RGFG 1995 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "RGR 1992 UTM Zone 40S"
p.PROJ4 = "+proj=utm +zone=40 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "RRAF 1991 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Saint Pierre et Miquelon 1950 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sainte Anne UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Samboja UTM Zone 50S"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sao Braz UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sapper Hill 1943 UTM Zone 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sapper Hill 1943 UTM Zone 21S"
p.PROJ4 = "+proj=utm +zone=21 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Schwarzeck UTM Zone 33S"
p.PROJ4 = "+proj=utm +zone=33 +south +ellps=bess_nam +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Selvagem Grande 1938 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sierra Leone 1968 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sierra Leone 1968 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=clrk80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 17S"
p.PROJ4 = "+proj=utm +zone=17 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 18S"
p.PROJ4 = "+proj=utm +zone=18 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 21S"
p.PROJ4 = "+proj=utm +zone=21 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 22S"
p.PROJ4 = "+proj=utm +zone=22 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 23S"
p.PROJ4 = "+proj=utm +zone=23 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 24S"
p.PROJ4 = "+proj=utm +zone=24 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "SIRGAS UTM Zone 25S"
p.PROJ4 = "+proj=utm +zone=25 +south +ellps=GRS80 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 17S"
p.PROJ4 = "+proj=utm +zone=17 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 18S"
p.PROJ4 = "+proj=utm +zone=18 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 21S"
p.PROJ4 = "+proj=utm +zone=21 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 22S"
p.PROJ4 = "+proj=utm +zone=22 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 23S"
p.PROJ4 = "+proj=utm +zone=23 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 24S"
p.PROJ4 = "+proj=utm +zone=24 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "South American 1969 UTM Zone 25S"
p.PROJ4 = "+proj=utm +zone=25 +south +ellps=aust_SA +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ST71 Belep UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ST84 Ile des Pins UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "ST87 Ouvea UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sudan UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Sudan UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tahaa UTM Zone 5S"
p.PROJ4 = "+proj=utm +zone=5 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tahiti UTM Zone 6S"
p.PROJ4 = "+proj=utm +zone=6 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tananarive 1925 UTM Zone 38S"
p.PROJ4 = "+proj=utm +zone=38 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tananarive 1925 UTM Zone 39S"
p.PROJ4 = "+proj=utm +zone=39 +south +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tete UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tete UTM Zone 37S"
p.PROJ4 = "+proj=utm +zone=37 +south +ellps=clrk66 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Timbalai 1948 UTM Zone 49N"
p.PROJ4 = "+proj=utm +zone=49 +ellps=evrstSS +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Timbalai 1948 UTM Zone 50N"
p.PROJ4 = "+proj=utm +zone=50 +ellps=evrstSS +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tokyo UTM Zone 51N"
p.PROJ4 = "+proj=utm +zone=51 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tokyo UTM Zone 52N"
p.PROJ4 = "+proj=utm +zone=52 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tokyo UTM Zone 53N"
p.PROJ4 = "+proj=utm +zone=53 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tokyo UTM Zone 54N"
p.PROJ4 = "+proj=utm +zone=54 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tokyo UTM Zone 55N"
p.PROJ4 = "+proj=utm +zone=55 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Tokyo UTM Zone 56N"
p.PROJ4 = "+proj=utm +zone=56 +ellps=bessel +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Trucial Coast 1948 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Trucial Coast 1948 UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=helmert +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Yemen NGN 1996 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Yemen NGN 1996 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Yoff 1972 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +a=6378249.2 +b=6356514.999904194 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Other GCS"
p.Name = "Zanderij 1972 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=intl +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 10N"
p.PROJ4 = "+proj=utm +zone=10 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 10S"
p.PROJ4 = "+proj=utm +zone=10 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 11N"
p.PROJ4 = "+proj=utm +zone=11 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 11S"
p.PROJ4 = "+proj=utm +zone=11 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 12N"
p.PROJ4 = "+proj=utm +zone=12 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 12S"
p.PROJ4 = "+proj=utm +zone=12 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 13N"
p.PROJ4 = "+proj=utm +zone=13 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 13S"
p.PROJ4 = "+proj=utm +zone=13 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 14N"
p.PROJ4 = "+proj=utm +zone=14 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 14S"
p.PROJ4 = "+proj=utm +zone=14 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 15N"
p.PROJ4 = "+proj=utm +zone=15 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 15S"
p.PROJ4 = "+proj=utm +zone=15 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 16N"
p.PROJ4 = "+proj=utm +zone=16 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 16S"
p.PROJ4 = "+proj=utm +zone=16 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 17S"
p.PROJ4 = "+proj=utm +zone=17 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 18S"
p.PROJ4 = "+proj=utm +zone=18 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 1N"
p.PROJ4 = "+proj=utm +zone=1 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 1S"
p.PROJ4 = "+proj=utm +zone=1 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 21S"
p.PROJ4 = "+proj=utm +zone=21 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 22S"
p.PROJ4 = "+proj=utm +zone=22 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 23N"
p.PROJ4 = "+proj=utm +zone=23 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 23S"
p.PROJ4 = "+proj=utm +zone=23 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 24N"
p.PROJ4 = "+proj=utm +zone=24 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 24S"
p.PROJ4 = "+proj=utm +zone=24 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 25N"
p.PROJ4 = "+proj=utm +zone=25 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 25S"
p.PROJ4 = "+proj=utm +zone=25 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 26S"
p.PROJ4 = "+proj=utm +zone=26 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 27N"
p.PROJ4 = "+proj=utm +zone=27 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 27S"
p.PROJ4 = "+proj=utm +zone=27 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 28S"
p.PROJ4 = "+proj=utm +zone=28 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 29S"
p.PROJ4 = "+proj=utm +zone=29 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 2N"
p.PROJ4 = "+proj=utm +zone=2 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 2S"
p.PROJ4 = "+proj=utm +zone=2 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 30S"
p.PROJ4 = "+proj=utm +zone=30 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 31S"
p.PROJ4 = "+proj=utm +zone=31 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 33S"
p.PROJ4 = "+proj=utm +zone=33 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 34S"
p.PROJ4 = "+proj=utm +zone=34 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 35S"
p.PROJ4 = "+proj=utm +zone=35 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 37S"
p.PROJ4 = "+proj=utm +zone=37 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 38S"
p.PROJ4 = "+proj=utm +zone=38 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 39S"
p.PROJ4 = "+proj=utm +zone=39 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 3N"
p.PROJ4 = "+proj=utm +zone=3 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 3S"
p.PROJ4 = "+proj=utm +zone=3 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 40S"
p.PROJ4 = "+proj=utm +zone=40 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 41N"
p.PROJ4 = "+proj=utm +zone=41 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 41S"
p.PROJ4 = "+proj=utm +zone=41 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 42N"
p.PROJ4 = "+proj=utm +zone=42 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 42S"
p.PROJ4 = "+proj=utm +zone=42 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 43N"
p.PROJ4 = "+proj=utm +zone=43 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 43S"
p.PROJ4 = "+proj=utm +zone=43 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 44N"
p.PROJ4 = "+proj=utm +zone=44 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 44S"
p.PROJ4 = "+proj=utm +zone=44 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 45N"
p.PROJ4 = "+proj=utm +zone=45 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 45S"
p.PROJ4 = "+proj=utm +zone=45 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 46N"
p.PROJ4 = "+proj=utm +zone=46 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 46S"
p.PROJ4 = "+proj=utm +zone=46 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 47S"
p.PROJ4 = "+proj=utm +zone=47 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 48S"
p.PROJ4 = "+proj=utm +zone=48 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 49N"
p.PROJ4 = "+proj=utm +zone=49 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 49S"
p.PROJ4 = "+proj=utm +zone=49 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 4N"
p.PROJ4 = "+proj=utm +zone=4 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 4S"
p.PROJ4 = "+proj=utm +zone=4 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 50N"
p.PROJ4 = "+proj=utm +zone=50 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 50S"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 51N"
p.PROJ4 = "+proj=utm +zone=51 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 51S"
p.PROJ4 = "+proj=utm +zone=51 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 52N"
p.PROJ4 = "+proj=utm +zone=52 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 52S"
p.PROJ4 = "+proj=utm +zone=52 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 53N"
p.PROJ4 = "+proj=utm +zone=53 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 53S"
p.PROJ4 = "+proj=utm +zone=53 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 54N"
p.PROJ4 = "+proj=utm +zone=54 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 54S"
p.PROJ4 = "+proj=utm +zone=54 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 55N"
p.PROJ4 = "+proj=utm +zone=55 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 55S"
p.PROJ4 = "+proj=utm +zone=55 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 56N"
p.PROJ4 = "+proj=utm +zone=56 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 56S"
p.PROJ4 = "+proj=utm +zone=56 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 57N"
p.PROJ4 = "+proj=utm +zone=57 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 57S"
p.PROJ4 = "+proj=utm +zone=57 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 58N"
p.PROJ4 = "+proj=utm +zone=58 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 59N"
p.PROJ4 = "+proj=utm +zone=59 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 59S"
p.PROJ4 = "+proj=utm +zone=59 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 5N"
p.PROJ4 = "+proj=utm +zone=5 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 5S"
p.PROJ4 = "+proj=utm +zone=5 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 60N"
p.PROJ4 = "+proj=utm +zone=60 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 60S"
p.PROJ4 = "+proj=utm +zone=60 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 6N"
p.PROJ4 = "+proj=utm +zone=6 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 6S"
p.PROJ4 = "+proj=utm +zone=6 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 7N"
p.PROJ4 = "+proj=utm +zone=7 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 7S"
p.PROJ4 = "+proj=utm +zone=7 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 8N"
p.PROJ4 = "+proj=utm +zone=8 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 8S"
p.PROJ4 = "+proj=utm +zone=8 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 9N"
p.PROJ4 = "+proj=utm +zone=9 +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1972"
p.Name = "WGS 1972 UTM Zone 9S"
p.PROJ4 = "+proj=utm +zone=9 +south +ellps=WGS72 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 20N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 21N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 22N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 23N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 24N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 25N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 26N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 27N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 28N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 29N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 Complex UTM Zone 30N"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 10N"
p.PROJ4 = "+proj=utm +zone=10 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 10S"
p.PROJ4 = "+proj=utm +zone=10 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 11N"
p.PROJ4 = "+proj=utm +zone=11 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 11S"
p.PROJ4 = "+proj=utm +zone=11 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 12N"
p.PROJ4 = "+proj=utm +zone=12 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 12S"
p.PROJ4 = "+proj=utm +zone=12 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 13N"
p.PROJ4 = "+proj=utm +zone=13 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 13S"
p.PROJ4 = "+proj=utm +zone=13 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 14N"
p.PROJ4 = "+proj=utm +zone=14 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 14S"
p.PROJ4 = "+proj=utm +zone=14 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 15N"
p.PROJ4 = "+proj=utm +zone=15 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 15S"
p.PROJ4 = "+proj=utm +zone=15 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 16N"
p.PROJ4 = "+proj=utm +zone=16 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 16S"
p.PROJ4 = "+proj=utm +zone=16 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 17N"
p.PROJ4 = "+proj=utm +zone=17 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 17S"
p.PROJ4 = "+proj=utm +zone=17 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 18N"
p.PROJ4 = "+proj=utm +zone=18 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 18S"
p.PROJ4 = "+proj=utm +zone=18 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 19N"
p.PROJ4 = "+proj=utm +zone=19 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 19S"
p.PROJ4 = "+proj=utm +zone=19 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 1N"
p.PROJ4 = "+proj=utm +zone=1 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 1S"
p.PROJ4 = "+proj=utm +zone=1 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 20N"
p.PROJ4 = "+proj=utm +zone=20 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 20S"
p.PROJ4 = "+proj=utm +zone=20 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 21N"
p.PROJ4 = "+proj=utm +zone=21 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 21S"
p.PROJ4 = "+proj=utm +zone=21 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 22N"
p.PROJ4 = "+proj=utm +zone=22 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 22S"
p.PROJ4 = "+proj=utm +zone=22 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 23N"
p.PROJ4 = "+proj=utm +zone=23 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 23S"
p.PROJ4 = "+proj=utm +zone=23 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 24N"
p.PROJ4 = "+proj=utm +zone=24 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 24S"
p.PROJ4 = "+proj=utm +zone=24 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 25N"
p.PROJ4 = "+proj=utm +zone=25 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 25S"
p.PROJ4 = "+proj=utm +zone=25 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 26N"
p.PROJ4 = "+proj=utm +zone=26 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 26S"
p.PROJ4 = "+proj=utm +zone=26 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 27N"
p.PROJ4 = "+proj=utm +zone=27 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 27S"
p.PROJ4 = "+proj=utm +zone=27 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 28N"
p.PROJ4 = "+proj=utm +zone=28 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 28S"
p.PROJ4 = "+proj=utm +zone=28 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 29N"
p.PROJ4 = "+proj=utm +zone=29 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 29S"
p.PROJ4 = "+proj=utm +zone=29 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 2N"
p.PROJ4 = "+proj=utm +zone=2 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 2S"
p.PROJ4 = "+proj=utm +zone=2 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 30N"
p.PROJ4 = "+proj=utm +zone=30 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 30S"
p.PROJ4 = "+proj=utm +zone=30 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 31N"
p.PROJ4 = "+proj=utm +zone=31 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 31S"
p.PROJ4 = "+proj=utm +zone=31 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 32N"
p.PROJ4 = "+proj=utm +zone=32 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 32S"
p.PROJ4 = "+proj=utm +zone=32 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 33N"
p.PROJ4 = "+proj=utm +zone=33 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 33S"
p.PROJ4 = "+proj=utm +zone=33 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 34N"
p.PROJ4 = "+proj=utm +zone=34 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 34S"
p.PROJ4 = "+proj=utm +zone=34 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 35N"
p.PROJ4 = "+proj=utm +zone=35 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 35S"
p.PROJ4 = "+proj=utm +zone=35 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 36N"
p.PROJ4 = "+proj=utm +zone=36 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 36S"
p.PROJ4 = "+proj=utm +zone=36 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 37N"
p.PROJ4 = "+proj=utm +zone=37 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 37S"
p.PROJ4 = "+proj=utm +zone=37 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 38N"
p.PROJ4 = "+proj=utm +zone=38 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 38S"
p.PROJ4 = "+proj=utm +zone=38 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 39N"
p.PROJ4 = "+proj=utm +zone=39 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 39S"
p.PROJ4 = "+proj=utm +zone=39 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 3N"
p.PROJ4 = "+proj=utm +zone=3 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 3S"
p.PROJ4 = "+proj=utm +zone=3 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 40N"
p.PROJ4 = "+proj=utm +zone=40 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 40S"
p.PROJ4 = "+proj=utm +zone=40 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 41N"
p.PROJ4 = "+proj=utm +zone=41 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 41S"
p.PROJ4 = "+proj=utm +zone=41 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 42N"
p.PROJ4 = "+proj=utm +zone=42 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 42S"
p.PROJ4 = "+proj=utm +zone=42 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 43N"
p.PROJ4 = "+proj=utm +zone=43 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 43S"
p.PROJ4 = "+proj=utm +zone=43 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 44N"
p.PROJ4 = "+proj=utm +zone=44 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 44S"
p.PROJ4 = "+proj=utm +zone=44 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 45N"
p.PROJ4 = "+proj=utm +zone=45 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 45S"
p.PROJ4 = "+proj=utm +zone=45 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 46N"
p.PROJ4 = "+proj=utm +zone=46 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 46S"
p.PROJ4 = "+proj=utm +zone=46 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 47N"
p.PROJ4 = "+proj=utm +zone=47 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 47S"
p.PROJ4 = "+proj=utm +zone=47 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 48N"
p.PROJ4 = "+proj=utm +zone=48 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 48S"
p.PROJ4 = "+proj=utm +zone=48 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 49N"
p.PROJ4 = "+proj=utm +zone=49 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 49S"
p.PROJ4 = "+proj=utm +zone=49 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 4N"
p.PROJ4 = "+proj=utm +zone=4 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 4S"
p.PROJ4 = "+proj=utm +zone=4 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 50N"
p.PROJ4 = "+proj=utm +zone=50 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 50S"
p.PROJ4 = "+proj=utm +zone=50 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 51N"
p.PROJ4 = "+proj=utm +zone=51 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 51S"
p.PROJ4 = "+proj=utm +zone=51 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 52N"
p.PROJ4 = "+proj=utm +zone=52 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 52S"
p.PROJ4 = "+proj=utm +zone=52 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 53N"
p.PROJ4 = "+proj=utm +zone=53 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 53S"
p.PROJ4 = "+proj=utm +zone=53 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 54N"
p.PROJ4 = "+proj=utm +zone=54 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 54S"
p.PROJ4 = "+proj=utm +zone=54 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 55N"
p.PROJ4 = "+proj=utm +zone=55 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 55S"
p.PROJ4 = "+proj=utm +zone=55 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 56N"
p.PROJ4 = "+proj=utm +zone=56 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 56S"
p.PROJ4 = "+proj=utm +zone=56 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 57N"
p.PROJ4 = "+proj=utm +zone=57 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 57S"
p.PROJ4 = "+proj=utm +zone=57 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 58N"
p.PROJ4 = "+proj=utm +zone=58 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 58S"
p.PROJ4 = "+proj=utm +zone=58 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 59N"
p.PROJ4 = "+proj=utm +zone=59 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 59S"
p.PROJ4 = "+proj=utm +zone=59 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 5N"
p.PROJ4 = "+proj=utm +zone=5 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 5S"
p.PROJ4 = "+proj=utm +zone=5 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 60N"
p.PROJ4 = "+proj=utm +zone=60 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 60S"
p.PROJ4 = "+proj=utm +zone=60 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 6N"
p.PROJ4 = "+proj=utm +zone=6 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 6S"
p.PROJ4 = "+proj=utm +zone=6 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 7N"
p.PROJ4 = "+proj=utm +zone=7 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 7S"
p.PROJ4 = "+proj=utm +zone=7 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 8N"
p.PROJ4 = "+proj=utm +zone=8 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 8S"
p.PROJ4 = "+proj=utm +zone=8 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 9N"
p.PROJ4 = "+proj=utm +zone=9 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "Utm - Wgs 1984"
p.Name = "WGS 1984 UTM Zone 9S"
p.PROJ4 = "+proj=utm +zone=9 +south +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Aitoff (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Behrmann (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Bonne (sphere)"
p.PROJ4 = "+proj=bonne +lon_0=0 +lat_1=60 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Craster Parabolic (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Cylindrical Equal Area (sphere)"
p.PROJ4 = "+proj=cea +lon_0=0 +lat_ts=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Eckert I (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Eckert II (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Eckert III (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Eckert IV (sphere)"
p.PROJ4 = "+proj=eck4 +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Eckert V (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Eckert VI (sphere)"
p.PROJ4 = "+proj=eck6 +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Equidistant Conic (sphere)"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=60 +lat_2=60 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Equidistant Cylindrical (sphere)"
p.PROJ4 = "+proj=eqc +lat_ts=0 +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Flat Polar Quartic (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Gall Stereographic (sphere)"
p.PROJ4 = "+proj=gall +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Hammer-Aitoff (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Loximuthal (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Mercator (sphere)"
p.PROJ4 = "+proj=merc +lat_ts=0 +lon_0=0 +k=1.000000 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Miller Cylindrical (sphere)"
p.PROJ4 = "+proj=mill +lat_0=0 +lon_0=0 +x_0=0 +y_0=0 +R_A +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Mollweide (sphere)"
p.PROJ4 = "+proj=moll +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Plate Carree (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Polyconic (sphere)"
p.PROJ4 = "+proj=poly +lat_0=0 +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Quartic Authalic (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Robinson (sphere)"
p.PROJ4 = "+proj=robin +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Sinusoidal (sphere)"
p.PROJ4 = "+proj=sinu +lon_0=0 +x_0=0 +y_0=0 +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Times (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Van der Grinten I (sphere)"
p.PROJ4 = "+proj=vandg +lon_0=0 +x_0=0 +y_0=0 +R_A +a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Vertical Perspective (sphere)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Winkel I (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Winkel II (sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World - Sphere-based"
p.Name = "Winkel Tripel (NGS - sphere)"
p.PROJ4 = "+a=6371000 +b=6371000 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Aitoff (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Behrmann (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Bonne (world)"
p.PROJ4 = "+proj=bonne +lon_0=0 +lat_1=60 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Craster Parabolic (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Cube (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Cylindrical Equal Area (world)"
p.PROJ4 = "+proj=cea +lon_0=0 +lat_ts=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Eckert I (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Eckert II (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Eckert III (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Eckert IV (world)"
p.PROJ4 = "+proj=eck4 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Eckert V (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Eckert VI (world)"
p.PROJ4 = "+proj=eck6 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Equidistant Conic (world)"
p.PROJ4 = "+proj=eqdc +lat_0=0 +lon_0=0 +lat_1=60 +lat_2=60 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Equidistant Cylindrical (world)"
p.PROJ4 = "+proj=eqc +lat_ts=0 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Flat Polar Quartic (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Fuller (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Gall Stereographic (world)"
p.PROJ4 = "+proj=gall +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Hammer-Aitoff (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Loximuthal (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Mercator (world)"
p.PROJ4 = "+proj=merc +lat_ts=0 +lon_0=0 +k=1.000000 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Miller Cylindrical (world)"
p.PROJ4 = "+proj=mill +lat_0=0 +lon_0=0 +x_0=0 +y_0=0 +R_A +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Mollweide (world)"
p.PROJ4 = "+proj=moll +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Plate Carree (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Polyconic (world)"
p.PROJ4 = "+proj=poly +lat_0=0 +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Quartic Authalic (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Robinson (world)"
p.PROJ4 = "+proj=robin +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Sinusoidal (world)"
p.PROJ4 = "+proj=sinu +lon_0=0 +x_0=0 +y_0=0 +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "The World from Space"
p.PROJ4 = "+proj=ortho +lat_0=42.5333333333 +lon_0=-72.5333333334 +x_0=0 +y_0=0 +a=6370997 +b=6370997 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Times (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Van der Grinten I (world)"
p.PROJ4 = "+proj=vandg +lon_0=0 +x_0=0 +y_0=0 +R_A +ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Vertical Perspective (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Winkel I (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Winkel II (world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
p = New clsProjection
p.MainCateg = "Projected Coordinate Systems"
p.Category = "World"
p.Name = "Winkel Tripel (NGS - world)"
p.PROJ4 = "+ellps=WGS84 +datum=WGS84 +units=m +no_defs "
ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Abidjan 1987"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Accra"
        p.PROJ4 = "+proj=longlat +a=6378300 +b=6356751.689189189 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Adindan"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Afgooye"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Agadez"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Ain el Abd 1970"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Arc 1950"
        p.PROJ4 = "+proj=longlat +a=6378249.145 +b=6356514.966395495 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Arc 1960"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Ayabelle Lighthouse"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Beduaram"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Bissau"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Camacupa"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Cape"
        p.PROJ4 = "+proj=longlat +a=6378249.145 +b=6356514.966395495 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Carthage (degrees)"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Carthage (Paris)"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Carthage"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Conakry 1905"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Cote d'Ivoire"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Dabola"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Douala 1948"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Douala"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Egypt 1907"
        p.PROJ4 = "+proj=longlat +ellps=helmert +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Egypt 1930"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "European Datum 1950"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "European Libyan Datum 1979"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Garoua"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Hartebeesthoek 1994"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Kousseri"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Kuwait Oil Company"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Kuwait Utility"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Leigon"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Liberia 1964"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Locodjo 1965"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Lome"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "M'poraloko"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Madzansua"
        p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Mahe 1971"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Malongo 1987"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Manoca 1962"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Manoca"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Massawa"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Merchich (degrees)"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Merchich"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Mhast"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Minna"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Moznet"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Nahrwan 1967"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "National Geodetic Network (Kuwait)"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Nord Sahara 1959 (Paris)"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +pm=2.337229166666667 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Nord Sahara 1959"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Observatario"
        p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Oman"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Palestine 1923"
        p.PROJ4 = "+proj=longlat +a=6378300.79 +b=6356566.430000036 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "PDO 1993"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Point 58"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Pointe Noire"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Qatar 1948"
        p.PROJ4 = "+proj=longlat +ellps=helmert +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Qatar"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Schwarzeck"
        p.PROJ4 = "+proj=longlat +ellps=bess_nam +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Sierra Leone 1924"
        p.PROJ4 = "+proj=longlat +a=6378300 +b=6356751.689189189 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Sierra Leone 1960"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Sierra Leone 1968"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "South Yemen"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Sudan"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Tananarive 1925 (Paris)"
        p.PROJ4 = "+proj=longlat +ellps=intl +pm=2.337229166666667 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Tananarive 1925"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Tete"
        p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Trucial Coast 1948"
        p.PROJ4 = "+proj=longlat +ellps=helmert +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Voirol 1875 (degrees)"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Voirol 1875 (Paris)"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +pm=2.337229166666667 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Voirol 1875"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Voirol Unifie 1960 (degrees)"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Voirol Unifie 1960 (Paris)"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +pm=2.337229166666667 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Voirol Unifie 1960"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Yemen NGN 1996"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Africa"
        p.Name = "Yoff"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Antarctica"
        p.Name = "Australian Antarctic 1998"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Antarctica"
        p.Name = "Camp Area Astro"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Antarctica"
        p.Name = "Deception Island"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Antarctica"
        p.Name = "Petrels 1972"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Antarctica"
        p.Name = "Pointe Geologie Perroud 1950"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Ain el Abd 1970"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Batavia (Jakarta)"
        p.PROJ4 = "+proj=longlat +ellps=bessel +pm=106.8077194444444 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Batavia"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Beijing 1954"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Bukit Rimpah"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Deir ez Zor"
        p.PROJ4 = "+proj=longlat +a=6378249.2 +b=6356514.999904194 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "European 1950 (ED77)"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "European Datum 1950"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest (def 1962)"
        p.PROJ4 = "+proj=longlat +a=6377301.243 +b=6356100.230165384 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest (def 1967)"
        p.PROJ4 = "+proj=longlat +ellps=evrstSS +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest (def 1975)"
        p.PROJ4 = "+proj=longlat +a=6377299.151 +b=6356098.145120132 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest - Bangladesh"
        p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest - India and Nepal"
        p.PROJ4 = "+proj=longlat +a=6377301.243 +b=6356100.230165384 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest 1830"
        p.PROJ4 = "+proj=longlat +a=6377299.36 +b=6356098.35162804 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Everest Modified"
        p.PROJ4 = "+proj=longlat +a=6377304.063 +b=6356103.041812424 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Fahud"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "FD 1958"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Gandajika 1970"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Gunung Segara (Jakarta)"
        p.PROJ4 = "+proj=longlat +ellps=bessel +pm=106.8077194444444 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Gunung Segara"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Hanoi 1972"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Herat North"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Hong Kong 1963"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Hong Kong 1980"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Hu Tzu Shan"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "IGM 1995"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "IKBD 1992"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Indian 1954"
        p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Indian 1960"
        p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Indian 1975"
        p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Indonesian Datum 1974"
        p.PROJ4 = "+proj=longlat +a=6378160 +b=6356774.50408554 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Israel"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "JGD 2000"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Jordan"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kalianpur 1880"
        p.PROJ4 = "+proj=longlat +a=6377299.36 +b=6356098.35162804 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kalianpur 1937"
        p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kalianpur 1962"
        p.PROJ4 = "+proj=longlat +a=6377301.243 +b=6356100.230165384 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kalianpur 1975"
        p.PROJ4 = "+proj=longlat +a=6377299.151 +b=6356098.145120132 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kandawala"
        p.PROJ4 = "+proj=longlat +a=6377276.345 +b=6356075.41314024 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kertau"
        p.PROJ4 = "+proj=longlat +a=6377304.063 +b=6356103.038993155 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Korean Datum 1985"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Korean Datum 1995"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kuwait Oil Company"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Kuwait Utility"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Luzon 1911"
        p.PROJ4 = "+proj=longlat +ellps=clrk66 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Makassar (Jakarta)"
        p.PROJ4 = "+proj=longlat +ellps=bessel +pm=106.8077194444444 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Makassar"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Nahrwan 1967"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "National Geodetic Network (Kuwait)"
        p.PROJ4 = "+proj=longlat +ellps=WGS84 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Observatorio Meteorologico 1965"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Oman"
        p.PROJ4 = "+proj=longlat +ellps=clrk80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Padang 1884 (Jakarta)"
        p.PROJ4 = "+proj=longlat +ellps=bessel +pm=106.8077194444444 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Padang 1884"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Palestine 1923"
        p.PROJ4 = "+proj=longlat +a=6378300.79 +b=6356566.430000036 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Pulkovo 1942"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Pulkovo 1995"
        p.PROJ4 = "+proj=longlat +ellps=krass +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Qatar 1948"
        p.PROJ4 = "+proj=longlat +ellps=helmert +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Qatar"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "QND 1995"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Rassadiran"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Samboja"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Segora"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Serindung"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "South Asia Singapore"
        p.PROJ4 = "+proj=longlat +ellps=fschr60m +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Timbalai 1948"
        p.PROJ4 = "+proj=longlat +ellps=evrstSS +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Tokyo"
        p.PROJ4 = "+proj=longlat +ellps=bessel +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Trucial Coast 1948"
        p.PROJ4 = "+proj=longlat +ellps=helmert +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Asia"
        p.Name = "Xian 1980"
        p.PROJ4 = "+proj=longlat +a=6378140 +b=6356755.288157528 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Australia and New Zealand"
        p.Name = "Australian Geodetic Datum 1966"
        p.PROJ4 = "+proj=longlat +ellps=aust_SA +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Australia and New Zealand"
        p.Name = "Australian Geodetic Datum 1984"
        p.PROJ4 = "+proj=longlat +ellps=aust_SA +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Australia and New Zealand"
        p.Name = "Chatham Islands 1979"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Australia and New Zealand"
        p.Name = "Geocentric Datum of Australia 1994"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Australia and New Zealand"
        p.Name = "New Zealand Geodetic Datum 1949"
        p.PROJ4 = "+proj=longlat +ellps=intl +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Australia and New Zealand"
        p.Name = "NZGD2000"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "County Systems"
        p.Name = "NAD 1983 HARN Adj WI Brown"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Europe"
        p.Name = "Estonia 1992"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
        p = New clsProjection
        p.MainCateg = "Geographic Coordinate Systems"
        p.Category = "Spheroid-based"
        p.Name = "GEM gravity potential model"
        p.PROJ4 = "+proj=longlat +ellps=GRS80 +no_defs "
        ProjectionList.Add(p)
    End Sub


End Class
