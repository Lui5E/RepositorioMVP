<?php
	session_start();
  if(!isset($_SESSION['bilbo']) || !isset($_SESSION['trabajador']))
		header('Location: index_logueo.php');
?>
<!DOCTYPE html>
<html>
	<head>
		<title>BILBO Institución X</title>
    <link rel="stylesheet" href="bootstrap-3.3.7/css/bootstrap.css">
		<script type="text/javascript" src="jquery.min.js"></script>
	  <script type="text/javascript" src="bootstrap-3.3.7/js/bootstrap.js"></script>
	</head>
	<body>
    <nav class="navbar navbar-inverse">
      <div class="container-fluid">
        <div class="navbar-header">

					<?php
		        if(isset($_SESSION['trabajador'])):
		       ?>
		      <a class="navbar-brand" href="#">
		        <?php echo($_SESSION['trabajador']['nombre']); ?>
		      </a>
		      <?php
		       endif;
		      ?>
        </div>

          <ul class="nav navbar-nav navbar-right">
            <li>
							<?php if($_SESSION['bilbo']['tipo_usuario'] == 1): ?>
								<a href="index_directivo.php">Inicio</a>
							<?php endif; ?>
							<?php if($_SESSION['bilbo']['tipo_usuario'] == 2): ?>
								<a href="index_docente.php">Inicio</a>
							<?php endif; ?>
							<?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
								<a href="index_terapeuta.php">Inicio</a>
							<?php endif; ?>
						</li>
            <li><a href="cerrar_sesion.php">Cerrar sesión</a></li>
          </ul>

      </div>
    </nav>
		<main class="">
