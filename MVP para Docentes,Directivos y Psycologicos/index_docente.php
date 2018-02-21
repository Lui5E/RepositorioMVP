<?php
  include('header.php');
  if(isset($_SESSION['bilbo']))
  {
    if($_SESSION['bilbo']['tipo_usuario'] != 2)
    {
      header('Location: index_logueo.php');
    }
  }
  else
  {
    header('Location: index_logueo.php');
  }
  $grupos = explode(",",$_SESSION['trabajador']['profesor_grupos']);
 ?>
 <div class="container">
   <div id="encabezado">
     <h2>Docente</h2>
   </div>
   <div id="contenido">
     <div id="clases">
       <div id="encabezado_clases">
         <p>Grupos asignados</p>
       </div>
       <div class="">
           <div class="input-group">
             <input type="text" class="form-control" placeholder="Buscar alumno...">
             <span class="input-group-btn">
               <button class="btn btn-default" type="button" onclick="openCity(event, 'Buscar')">Buscar</button>
             </span>
           </div>
       </div>
       <div id="alumno" style="display: none;">
         <div class="alumno col-md-3">
           <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
           <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Alonso Navarro Rubén</a>"; ?></h3>
         </div>
         <div class="col-md-offset-5">

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

     </div>

   </div>
 </div>
 </div>

<?php include('footer.php'); ?>
<link rel="stylesheet" type="text/css" href="assets/css/views/index_docente.css">
<script type="text/javascript" src="assets/js/views/index_docente.js"></script>
