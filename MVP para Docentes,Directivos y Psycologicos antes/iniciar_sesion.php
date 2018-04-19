<?php
	session_start();
	$tipo_usuario = 0;

	try {
		$conn = new mysqli('localhost', 'root', '', 'bilbo');

		if(!$conn->connect_error){
			$correo = $_POST['correo'];
			$clave = $_POST['clave'];
			$sql = "
				select
					*
				from
					trabajadores_institucion
				where
					usuario = '".$correo."'
					and clave = '".$clave."'";
			$sql_respuesta = $conn->query($sql);

			//echo($sql);	// imprime el contenido de la variable $sql
			//var_dump($sql_respuesta);	// imprime el contenido de la variable $sql_respuesta, este método funciona para visualizar arrays

			// ciclo que recorre cada fila obtenida en el select, en este caso cada fila se obtiene en un vector asociativo, investogar de vectores asociativos
      if($sql_respuesta)
      {
        while($row = $sql_respuesta->fetch_assoc()){
  				//var_dump($row);	// imprime cada fila para ver la estructura del vector asociativo
  				$_SESSION['bilbo'] = $row;
          $tipo_usuario = $row['tipo_usuario'];
  			}
				//mysql_data_seek($sql_respuesta,0);		//Regreso el puntero a la mprimera posición
				mysqli_data_seek($sql_respuesta,0);
				if($tipo_usuario == 1){
					$sql2 = "
						select
							*
						from
							terapeutas
						where
							usuario = '".$correo."'
							and clave = '".$clave."'";
					$sql_respuesta_usuario = $conn->query($sql2);
				}
				else if ($tipo_usuario == 2) {
					$sql2 = "
						select
							*
						from
							profesores
						where
							usuario = '".$correo."'
							and clave = '".$clave."'";
					$sql_respuesta_usuario = $conn->query($sql2);
					echo("<script>console.log('PHP: ');</script>");
				}
				else if ($tipo_usuario == 3) {
					$sql2 = "
						select
							*
						from
							terapeutas
						where
							usuario = '".$correo."'
							and clave = '".$clave."'";
					$sql_respuesta_usuario = $conn->query($sql2);
				}
				if($sql_respuesta_usuario)
	      {
	        while($row_usuario = $sql_respuesta_usuario->fetch_assoc()){
	  				//var_dump($row);	// imprime cada fila para ver la estructura del vector asociativo
	  				$_SESSION['trabajador'] = $row_usuario;//array('tipo_usuario' => $tipo_usuario, 'profesor_nombre' => $row['profesor_nombre']);
	  			}
				}else {
					$nombre = "No hay respuesta de trabajador";

				}
			}
	 }
	 else{
		 echo "Error al conectar a la BD";
	 }
	} catch (Exception $e){}

	if($tipo_usuario == 0 || (!isset($_SESSION['trabajador']))){
		header('Location: index_logueo.php?error=1');
	}
  else if($tipo_usuario == 1){
		header('Location: index_directivo.php');
	}
  else if($tipo_usuario == 2){
    header('Location: index_docente.php');
  }
  else{
    header('Location: index_terapeuta.php');
  }

?>
