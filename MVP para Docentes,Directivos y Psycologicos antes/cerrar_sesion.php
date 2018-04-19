<?php
	session_start();

	if(isset($_SESSION['bilbo']))
  {
    unset($_SESSION['bilbo']);
  }
	if(isset($_SESSION['trabajador']))
	{
		unset($_SESSION['trabajador']);
	}
	header('Location: index_logueo.php');
?>
