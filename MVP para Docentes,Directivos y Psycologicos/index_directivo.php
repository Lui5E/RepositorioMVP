<?php
  include('header.php');
  if(isset($_SESSION['bilbo']))
  {
    if($_SESSION['bilbo']['tipo_usuario'] != 1)
    {
      header('Location: index_logueo.php');
    }
  }
  else
  {
    header('Location: index_logueo.php');
  }
  $grupos = array('1A', '1B', '1C', '3C', '4A', '4B', '6G', '6H', '7B');
  $grupos_profesores = array('1C', '6G', '7B');
  $profesores = array('Claudia Ruíz Gutiérrez', 'Oscar Puente Jimenes', 'Mario Alberto García García');
 ?>
 <div class="container">
   <div id="encabezado">
     <h2>Director</h2>
   </div>
   <div id="contenido">
     <div id="clases">
       <div id="encabezado_clases">

       </div>
       <div class="">
           <div class="input-group">
             <input type="text" class="form-control" placeholder="Buscar alumno...">
             <span class="input-group-btn">
               <button class="btn btn-default" type="button" onclick="openCity(event, 'Buscar')">Buscar</button>
             </span>
           </div>
       </div>
       <div class="opciones">
         <div class="Grupos">
           <button class="btn btn-default grupos btn-info" type="button" onclick="Grupos(event, 'Buscar')">Mostrar todos los grupos</button>
           <button class="btn btn-default profesores btn-info" type="button" onclick="Profesores(event, 'Buscar')">Mostrar profesores</button>
         </div>
         <div class="Profesores">

         </div>
       </div>
       <div id="alumno" style="display: none; margin-top: 5em; margin-bottom: 5em;">
         <div class="alumno col-md-3">
           <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
           <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Alonso Navarro Rubén</a>"; ?></h3>
         </div>
         <div class="col-md-offset-5" style="margin-top: 5em; margin-bottom: 5em; padding-top: 2em;">

             <button class="btn btn-info" type="button" onclick="openGroup(event, 'Regresar')"><span class="glyphicon glyphicon-th"></span>   Mostrar grupos</button>

         </div>
       </div>
       <div class="row" id="contenedor_grupos">
         <?php
         foreach ($grupos as $valor)
         {
           echo "<div class='grupos col-md-3 col-md-offset-1'>
                  <a href='alumnos_clase.php?Grupo=6G'>$valor</a>
                </div>";
         }
         ?>
       </div>

       <div class="row" id="contenedor_profesores" style="display: none">
         <?php
         foreach ($profesores as $valor)
         {
           echo "<div class='grupos col-md-3 col-md-offset-1'>
                  <a onclick='tres()'><h4>$valor</h4></a>
                </div>";
         }
         ?>
       </div>
       <div class="row" id="grupos_profesores" style="display: none">
         <?php
         foreach ($grupos_profesores as $valor)
         {
           echo "<div class='grupos col-md-3 col-md-offset-1'>
                  <a href='alumnos_clase.php?Grupo=6G'><h4>$valor</h4></a>
                </div>";
         }
         ?>
       </div>

     </div>

   </div>
 </div>
 </div>

<?php include('footer.php'); ?>
<link rel="stylesheet" type="text/css" href="assets/css/views/index_directivo.css">
<script type="text/javascript" src="assets/js/views/index_directivo.js"></script>
