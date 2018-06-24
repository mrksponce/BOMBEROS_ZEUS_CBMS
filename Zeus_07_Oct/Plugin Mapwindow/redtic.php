<?php
$id_sgc = $HTTP_GET_VARS['id_sgc'];
$servicio=  $HTTP_GET_VARS['servicio'];
$hora=  $HTTP_GET_VARS['hora'];
$fecha=  $HTTP_GET_VARS['fecha'];
$direccion=  $HTTP_GET_VARS['direccion'];
$comuna= $HTTP_GET_VARS['comuna'];
$esquina_ref= $HTTP_GET_VARS['esquina_ref'];
$villa= $HTTP_GET_VARS['villa'];
$block= $HTTP_GET_VARS['block'];
$casa= $HTTP_GET_VARS['casa'];
$telefono= $HTTP_GET_VARS['telefono'];
$quien_llama= $HTTP_GET_VARS['quien_llama'];
$cia_termina= $HTTP_GET_VARS['cia_termina'];
$descripcion= $HTTP_GET_VARS['descripcion'];

// verificar...
$error =  false;
//...
if ($error != true)
{
	echo 'OK';
}
else
{
	echo 'NO';
}
