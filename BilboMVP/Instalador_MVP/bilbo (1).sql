-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-01-2018 a las 02:30:48
-- Versión del servidor: 10.1.28-MariaDB
-- Versión de PHP: 7.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bilbo`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumnos`
--

CREATE TABLE `alumnos` (
  `alumno_id` int(11) NOT NULL,
  `usuario` text NOT NULL,
  `contraseña` text NOT NULL,
  `alumno_nombre` text NOT NULL,
  `alumno_grado` int(11) NOT NULL,
  `alumno_grupo` text NOT NULL,
  `alumno_tipo_cuestionario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `alumnos`
--

INSERT INTO `alumnos` (`alumno_id`, `usuario`, `contraseña`, `alumno_nombre`, `alumno_grado`, `alumno_grupo`, `alumno_tipo_cuestionario`) VALUES
(1, 'lrangel2@ucol.mx', 'si.51', 'Luis Enrique Rangel Delgado', 6, 'G', 1),
(2, 'usuario02@correo.com', 'usuario.02', 'Usuario de prueba 02', 1, 'A', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuestionarios`
--

CREATE TABLE `cuestionarios` (
  `ID` int(11) NOT NULL,
  `cuestionario_id` int(11) NOT NULL COMMENT 'Identificador del cuestionario',
  `numero_instruccion` int(11) NOT NULL,
  `tipo_instruccion` int(11) NOT NULL COMMENT 'Contexto=1 , Panas=2',
  `instruccion` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cuestionarios`
--

INSERT INTO `cuestionarios` (`ID`, `cuestionario_id`, `numero_instruccion`, `tipo_instruccion`, `instruccion`) VALUES
(1, 1, 1, 1, 'Escribe aquí abajo como te fue el fin de semana.'),
(2, 1, 2, 1, 'Escribe aquí abajo que hiciste este fin de semana.'),
(3, 1, 3, 1, 'Escribe aquí abajo lo que más haya resaltado, sobre lo sucedido el fin de semana. '),
(4, 1, 4, 2, 'De lo más positivo que te haya pasado este fin de semana, indica en qué medida te sentiste de esta manera.'),
(5, 1, 5, 2, 'De lo más negativo que te haya pasado este fin de semana, indica en qué medida te sentiste de esta manera.');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuestas_alumnos`
--

CREATE TABLE `respuestas_alumnos` (
  `alumno_id` int(11) NOT NULL COMMENT 'Identificador del alumno que respondió ',
  `cuestionario_id` int(11) NOT NULL COMMENT 'Identificador de cuestionario',
  `numero_respuesta` int(11) NOT NULL COMMENT 'Orden de la respuesta con respecto al cuestionario contestado',
  `tipo_respuesta` int(11) NOT NULL COMMENT 'Contexto=1 , Panas=2',
  `respuesta` varchar(1000) NOT NULL COMMENT 'Respuesta del alumno'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `respuestas_alumnos`
--

INSERT INTO `respuestas_alumnos` (`alumno_id`, `cuestionario_id`, `numero_respuesta`, `tipo_respuesta`, `respuesta`) VALUES
(2, 1, 1, 2, 'Bien'),
(2, 1, 1, 1, 'sad'),
(2, 1, 1, 1, 'sad'),
(2, 1, 1, 1, 'sad'),
(2, 1, 1, 1, 'sad'),
(2, 1, 1, 1, 'sad'),
(2, 1, 1, 1, 'sad'),
(2, 1, 1, 1, 'Bien'),
(2, 1, 2, 1, 'Hacer este programa :D'),
(2, 1, 3, 1, 'El tiempo que me tomo hacer este programa.'),
(2, 1, 4, 2, '5,1,3,1,4,1,1,1,3,4,1,3,3,1,2,5,4,1,3,1'),
(2, 1, 5, 2, '5,5,5,5,5,1,1,1,3,4,1,3,3,1,2,5,4,1,3,1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sesion`
--

CREATE TABLE `sesion` (
  `ID` int(11) NOT NULL,
  `fecha_sesion` date NOT NULL,
  `sesion_cuestionario_id` int(11) NOT NULL COMMENT 'Cuestionario a aplicar ese día',
  `sesion_alumno_tipo_cuestionario` int(11) NOT NULL COMMENT 'Grupo de alumnos a los que se les aplicara ese cuestionario'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sesion`
--

INSERT INTO `sesion` (`ID`, `fecha_sesion`, `sesion_cuestionario_id`, `sesion_alumno_tipo_cuestionario`) VALUES
(1, '2018-01-19', 1, 1),
(2, '2018-01-19', 1, 2),
(3, '2018-01-20', 1, 2),
(4, '2018-01-22', 1, 2),
(5, '2018-01-23', 1, 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `alumnos`
--
ALTER TABLE `alumnos`
  ADD PRIMARY KEY (`alumno_id`);

--
-- Indices de la tabla `cuestionarios`
--
ALTER TABLE `cuestionarios`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `sesion`
--
ALTER TABLE `sesion`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `alumnos`
--
ALTER TABLE `alumnos`
  MODIFY `alumno_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cuestionarios`
--
ALTER TABLE `cuestionarios`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `sesion`
--
ALTER TABLE `sesion`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
