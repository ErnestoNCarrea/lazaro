SET FOREIGN_KEY_CHECKS=0;

/*
	Renombrar campos
	articulos.fecha_creado	-> fecha
	articulos_categorias.requierens -> seguimiento
	tickets.fecha_ingreso	-> fecha
*/

/* Renombrar tablas
	alicuotas			-> impu_alicuotas
	chequeras			-> bancos_chequeras
	ciudades			-> localidades
	conceptos			-> cajas_conceptos
	documentos_tipos	-> docu_tipos
	marcas				-> articulos_marcas
	margenes			-> articulos_margenes
	pvs					-> comprob_pvs
	situaciones			-> impu_situaciones
	talonarios			-> comprob_talonarios
	tipo_doc			-> personas_tipodoc
	tickets*			-> tareas*
	sys_plantillas		-> docu_plantillas
	tarjetas_planes		-> formaspago_planes
	tarjetas_cupones	-> formaspago_cupones
*/

SET FOREIGN_KEY_CHECKS=1;
