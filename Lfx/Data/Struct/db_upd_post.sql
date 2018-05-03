SET FOREIGN_KEY_CHECKS=0;

UPDATE documentos_tipos SET tipobase='Lbl.Comprobantes.ComprobanteFacturable'
	WHERE tipo IN ('Lbl.Comprobantes.Factura', 'Lbl.Comprobantes.NotaDeCredito', 'Lbl.Comprobantes.NotaDeDebito', 'Lbl.Comprobantes.Ticket');

UPDATE documentos_tipos SET tipobase='Lbl.Comprobantes.Recibo'
	WHERE tipo IN ('Lbl.Comprobantes.ReciboDeCobro', 'Lbl.Comprobantes.ReciboDePago');

/* UPDATE personas SET saldo_ctacte = (SELECT SUM(importe)  FROM ctacte WHERE ctacte.id_cliente=personas.id_persona)
	WHERE personas.id_persona IN (SELECT DISTINCT id_cliente FROM ctacte) */

UPDATE "sys_permisos_objetos" SET "clase"='Lazaro\\Base\\Persona' WHERE "tipo"='Lbl.Personas.Persona';
UPDATE "sys_permisos_objetos" SET "clase"='Global' WHERE "tipo"='Global';

UPDATE "documentos_tipos" SET "imprimir_repetir"=0 WHERE "id_tipo"=3;

UPDATE sys_config SET valor=REPLACE(valor, 'www.sistemalazaro.com.ar', 'www.lazarogestion.com');
UPDATE sys_components SET url=REPLACE(url, 'www.sistemalazaro.com.ar', 'www.lazarogestion.com');
UPDATE sys_components SET url_act=REPLACE(url_act, 'www.sistemalazaro.com.ar', 'www.lazarogestion.com');
UPDATE sys_config SET fecha=NOW() WHERE fecha IS NULL;

/* UPDATE comprob_detalle cd 
	SET id_alicuota = 
		COALESCE(
			(SELECT ac.id_alicuota FROM articulos_categorias ac LEFT JOIN articulos a ON a.id_categoria=ac.id_categoria WHERE a.id_articulo=cd.id_articulo),
			(SELECT ar.id_alicuota FROM articulos_rubros ar LEFT JOIN articulos_categorias ac ON ar.id_rubro=ac.id_rubro LEFT JOIN articulos a ON a.id_categoria=ac.id_categoria WHERE a.id_articulo=cd.id_articulo),
			1)
    WHERE id_alicuota IS NULL
		AND id_articulo IS NOT NULL; */

/* UPDATE comprob_detalle cd 
	SET cd.iva=cd.precio-cd.precio/(1+(SELECT COALESCE(al.porcentaje, 0)/100 FROM alicuotas al WHERE al.id_alicuota=cd.id_alicuota))
	    WHERE cd.iva=0
    AND cd.id_comprob IN (
		SELECT comprob.id_comprob
			FROM comprob 
				LEFT JOIN personas ON comprob.id_cliente=personas.id_persona
			WHERE comprob.tipo_fac IN ('FB', 'NCB', 'NDB') AND comprob.compra=0
				AND personas.id_ciudad NOT IN (SELECT id_ciudad FROM ciudades WHERE id_provincia=24)
        ); */

/* UPDATE comprob c SET
	total=(SELECT SUM(cd.total) FROM comprob_detalle cd WHERE cd.id_comprob=c.id_comprob) * (1-c.descuento/100),
	iva=(SELECT SUM(cd.iva) FROM comprob_detalle cd WHERE cd.id_comprob=c.id_comprob) * (1-c.descuento/100)
	WHERE compra=0; */

UPDATE sys_plantillas SET defxml=REPLACE(defxml, '{Precios}', '{Articulos.Unitarios}');
UPDATE sys_plantillas SET defxml=REPLACE(defxml, '{Importes}', '{Articulos.Importes}');
UPDATE sys_plantillas SET defxml=REPLACE(defxml, '{Detalles}', '{Articulos.Detalles}');
UPDATE sys_plantillas SET defxml=REPLACE(defxml, '{Cantidades}', '{Articulos.Cantidades}');

UPDATE sys_config SET valor=REPLACE(valor, '/aslnlwc/{0}/', '/act/{0}/');
UPDATE sys_components SET url_act=REPLACE(url_act, '/aslnlwc/{0}/', '/act/{0}/');

UPDATE comprob_detalle
	SET total=importe+iva
    WHERE comprob_detalle.id_comprob IN 
		(SELECT id_comprob FROM comprob WHERE tipo_fac IN ('FA', 'NCA', 'NDA'));

UPDATE comprob SET cancelado=total WHERE ABS(total-cancelado)<0.01;

SET FOREIGN_KEY_CHECKS=1;