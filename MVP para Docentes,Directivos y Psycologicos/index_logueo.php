<?php
	session_start();

	if(isset($_SESSION['bilbo'])){
		if($_SESSION['bilbo']['tipo_usuario'] == 1)
		{
			header('Location: index_directivo.php');
		}
		else if($_SESSION['bilbo']['tipo_usuario'] == 2)
		{
			header('Location: index_docente.php');
		}
		else if($_SESSION['bilbo']['tipo_usuario'] == 3)
		{
			header('Location: index_psycologo.php');
		}

	}
?>
<!DOCTYPE html>
<html>
	<head>
		<title>PHP</title>
		<link rel="stylesheet" href="bootstrap-3.3.7/css/bootstrap.css">
	  <script type="text/javascript" src="bootstrap-3.3.7/js/bootstrap.min.js"></script>
		<script type="text/javascript" src="assets/js/libs/jquery.validate.min.js"></script>
		<link rel="stylesheet" type="text/css" href="assets/css/views/index_logueo.css">
	</head>
	<body>
		<header>
			<section class="container">
				<div class="col-xs-12">
					<h1>BILBO</h1>
					<!--<span class="help-block">Iniciar sesión</span>-->
				</div>
			</section>
		</header>
		<main>
			<section class="container">
				<div class="col-xs-12">
					<form name="frminiciarsesion" class="col-xs-12 col-md-6 col-md-offset-3" method="post" action="iniciar_sesion.php">
						<div class="col-xs-12">
							<img src="assets/resources/images/emociones1.png">
						</div>
						<div class="col-xs-12 datos">
							<?php
								if(isset($_GET['error'])):
							?>
								<div class="col-xs-12 alert alert-warning">
									El correo electrónico y/o contraseña es/son incorrecto(s)
								</div>
							<?php
								endif;
							?>
							<div class="col-xs-12">
								<h2>Iniciar sesión</h2>
								<span>Favor de ingresar todos los datos solicitados</span>
							</div>
							<div class="form-group">
								<input type="email" placeholder="Correo electrónico" name="correo" class="form-control input-md" maxlength="30" required>
							</div>
							<div class="form-group">
								<input type="password" placeholder="Contraseña" name="clave" class="form-control input-md" maxlength="20" required>
							</div>
							<div class="form-group">
								<input type="submit" value="Iniciar sesión" class="form-control btn btn-info" name="looggin">
							</div>
						</div>
						<div class="col-xs-12">
							<p>
								En caso de no contar con alguno de los datos puede recuperar su contraseña dando click <a href="javascript: void(0)">AQUI</a>
							</p>
						</div>
					</form>
				</div>
			</section>
		</main>
		<footer>
		</footer>
		<script type="text/javascript">
			// errorPlacement evita que se muestren los mensajes de error
			$("form").validate({ errorPlacement: function(error, element) {} });
		</script>
	</body>
</html>
