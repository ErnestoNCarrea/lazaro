SET FOREIGN_KEY_CHECKS=0;

DROP TABLE IF EXISTS quickpaste;
DROP TABLE IF EXISTS sys_accessbase;
DROP TABLE IF EXISTS sys_accesslist;
DROP TABLE IF EXISTS sys_asl;
DROP TABLE IF EXISTS tarjetas;


UPDATE comprob SET nombre=CONCAT(LPAD(comprob.pv, 4, '0'), '-', LPAD(comprob.numero, 8, '0')) WHERE nombre='';
UPDATE recibos SET nombre=CONCAT(LPAD(recibos.pv, 4, '0'), '-', LPAD(recibos.numero, 8, '0')) WHERE nombre='';
UPDATE comprob SET cancelado=total WHERE tipo_fac IN ('R', 'NV', 'PS', 'NP', 'PD');
UPDATE articulos SET unidad_stock='u' WHERE unidad_stock='' OR unidad_stock IS NULL;
DELETE FROM sys_log WHERE comando='LogOff';
UPDATE sys_log SET comando='LogOn' WHERE comando='Logon';
UPDATE ciudades SET iva=1 WHERE id_ciudad=24;
UPDATE documentos_tipos SET compra=1 WHERE id_tipo NOT IN (53, 54, 58);
UPDATE documentos_tipos SET venta=1 WHERE id_tipo NOT IN (58);

REPLACE INTO "sys_permisos_objetos" ("id_objeto","nombre","obs","estado","fecha","tipo","extra1_nombre","extra2_nombre","extra3_nombre","extraa_nombre","extrab_nombre","extrac_nombre") VALUES (42,'Evento del historial',NULL,0,NOW(),'Lbl.Sys.Log.Entrada',NULL,NULL,NULL,NULL,NULL,NULL);

REPLACE INTO "monedas" ("id_moneda", "nombre", "obs", "estado", "fecha", "signo", "iso", "cotizacion", "decimales") VALUES
	(1, 'Dólares', NULL, 1, NULL, 'USD', 'USD', 1.0000, 2),
	(2, 'Euros', NULL, 1, NULL, '€', 'EUR', 1.0000, 2),
	(3, 'Pesos Argentinos', NULL, 1, NULL, '$', 'ARS', 1.0000, 2),
	(4, 'Pesos Uruguayos', NULL, 1, NULL, '$', 'UYU', 1.0000, 2),
	(5, 'Pesos Chilenos', NULL, 1, NULL, '$', 'CLP', 1.0000, 0),
	(6, 'Reales', NULL, 1, NULL, 'R$', 'BRL', 1.0000, 2),
	(7, 'Guaraníes', NULL, 1, NULL, 'Gs', 'PYG', 1.0000, 2),
	(8, 'Pesos Bolivianos', NULL, 1, NULL, '$', 'BOB', 1.0000, 2),
	(9, 'Soles', NULL, 1, NULL, 'S/.', 'PEN', 1.0000, 2),
	(11, 'Pesos Colombianos', NULL, 1, NULL, '$', 'COP', 1.0000, 2),
	(12, 'Bolívares', NULL, 1, NULL, 'Bs', 'VEF', 1.0000, 2),
	(13, 'Colones de Costa Rica', NULL, 1, NULL, 'CRC', 'CRC', 1.0000, 2),
	(14, 'Pesos Cubanos', NULL, 1, NULL, 'P', 'CUP', 1.0000, 2),
	(15, 'Colones de El Salvador', NULL, 1, NULL, '$', 'SVC', 1.0000, 2),
	(16, 'Quetzales', NULL, 1, NULL, 'Q', 'GTQ', 1.0000, 2),
	(17, 'Pesos Mexicanos', NULL, 1, NULL, '$', 'MXN', 1.0000, 2),
	(18, 'Córdobas', NULL, 1, NULL, 'C$', 'NIO', 1.0000, 2),
	(19, 'Balboas', NULL, 1, NULL, 'B/.', 'PAB', 1.0000, 2),
	(20, 'Pesos Dominicanos', NULL, 1, NULL, 'RD$', 'DOP', 1.0000, 2),
	(21, 'Lempira ', NULL, 1, NULL, 'L', 'HNL', 1.0000, 2);


REPLACE INTO "paises" ("id_pais", "nombre", "obs", "estado", "fecha", "iso", "clavefis", "clavejur", "claveban", "id_moneda", "iva1", "iva2") VALUES
	(1, 'Argentina', NULL, 1, NULL, 'AR', 1, 6, 82, 3, 21.0000, 10.5000),
	(2, 'España', NULL, 1, NULL, 'ES', 1, 20, 81, 2, 18.0000, 8.0000),
	(3, 'Chile', NULL, 1, NULL, 'CL', 4, 16, 80, 5, 19.0000, 0.0000),
	(4, 'México', NULL, 1, NULL, 'MX', 8, 24, 83, 17, 16.0000, 11.0000),
	(5, 'Uruguay', NULL, 1, NULL, 'UY', 4, 19, 80, 4, 22.0000, 10.0000),
	(6, 'Paraguay', NULL, 1, NULL, 'PY', 4, 28, 80, 7, 10.0000, 5.0000),
	(7, 'Bolivia', NULL, 1, NULL, 'BO', 4, 14, 80, 8, 13.0000, 0.0000),
	(8, 'Colombia', NULL, 1, NULL, 'CO', 10, 14, 80, 11, 16.0000, 1.0000),
	(9, 'Venezuela', NULL, 1, NULL, 'VE', 4, 15, 80, 12, 12.0000, 8.0000),
	(10, 'Ecuador', NULL, 1, NULL, 'EC', 4, 25, 80, 1, 12.0000, 0.0000),
	(11, 'Perú', NULL, 1, NULL, 'PE', 1, 25, 80, 9, 18.0000, 0.0000),
	(12, 'Panamá', NULL, 1, NULL, 'PA', 4, 25, 80, 19, 7.0000, 0.0000),
	(13, 'Guatemala', NULL, 1, NULL, 'GT', 12, 26, 80, 16, 12.0000, 0.0000),
	(14, 'El Salvador', NULL, 1, NULL, 'SV', 11, 14, 80, 15, 13.0000, 0.0000),
	(15, 'República Dominicana', NULL, 1, NULL, 'DO', 9, 18, 80, 20, 16.0000, 0.0000),
	(16, 'Cuba', NULL, 1, NULL, 'CU', 4, 28, 80, 14, 0.0000, 0.0000),
	(17, 'Brazil', NULL, 1, NULL, 'BR', 4, 27, 80, 6, 18.0000, 7.0000),
	(18, 'Costa Rica', NULL, 1, NULL, 'CR', 4, 28, 80, 13, 13.0000, 0.0000),
	(19, 'Honduras', NULL, 1, NULL, 'HN', 4, 28, 80, 21, 12.0000, 0.0000),
	(20, 'Nicaragua', NULL, 1, NULL, 'NI', 4, 28, 80, 18, 15.0000, 0.0000),
	(99, 'Estados Unidos', NULL, 1, NULL, 'US', 22, 23, 80, 1, 0.0000, 0.0000);

UPDATE "documentos_tipos" SET nombrelargo=nombre WHERE nombrelargo='';
UPDATE "documentos_tipos" SET letrasola='A' WHERE id_tipo IN (1, 11, 21);
UPDATE "documentos_tipos" SET letrasola='B' WHERE id_tipo IN (2, 12, 22);
UPDATE "documentos_tipos" SET letrasola='C' WHERE id_tipo IN (3, 13, 23);
UPDATE "documentos_tipos" SET letrasola='E' WHERE id_tipo IN (4, 14, 24);
UPDATE "documentos_tipos" SET letrasola='M' WHERE id_tipo IN (5, 15, 25);

UPDATE documentos_tipos SET tipo='Lbl.Comprobantes.Factura' WHERE id_tipo IN (1,2,3,4,5);
UPDATE documentos_tipos SET tipo='Lbl.Comprobantes.NotaDeCredito' WHERE id_tipo IN (11,12,13,14,15);
UPDATE documentos_tipos SET tipo='Lbl.Comprobantes.NotaDeDebito' WHERE id_tipo IN (21,22,23,24,25);

UPDATE documentos_tipos SET direc_ctacte=1 WHERE tipo='Lbl.Comprobantes.Factura';
UPDATE documentos_tipos SET direc_ctacte=-1 WHERE tipo='Lbl.Comprobantes.NotaDeCredito';
UPDATE documentos_tipos SET direc_ctacte=1 WHERE tipo='Lbl.Comprobantes.NotaDeDebito';

REPLACE INTO "sys_components" ("id_component", "nombre", "obs", "estado", "fecha", "espacio", "version", "estructura", "cif", "url", "url_act") VALUES
	(1, 'ServidorFiscal', NULL, 1, NULL, 'ServidorFiscal', NOW(), NULL, NULL, 'http://www.lazarogestion.com', 'http://www.lazarogestion.com/act/{0}/Components/');


START TRANSACTION WITH CONSISTENT SNAPSHOT;
INSERT INTO sys_log (fecha, estacion, usuario, comando, tabla, item_id, extra1) SELECT fecha, '', id_persona, 'Comment', tablas, item_id, obs FROM sys_comments;
DELETE FROM sys_comments;
COMMIT;
UPDATE sys_log SET tabla=NULL WHERE comando='LogOn' OR comando='LogOnFail';

UPDATE pvs SET nombre=LPAD(numero, 4, '0') WHERE nombre='' OR nombre IS NULL;
UPDATE sucursales SET nombre='Casa central' WHERE nombre='Sucursal 1';

UPDATE documentos_tipos SET tipobase='Lbl.Comprobantes.ComprobanteFacturable'
	WHERE (tipobase IS NULL OR tipobase='') AND tipo IN ('Lbl.Comprobantes.Factura', 'Lbl.Comprobantes.NotaDeCredito', 'Lbl.Comprobantes.NotaDeDebito', 'Lbl.Comprobantes.Ticket');
UPDATE documentos_tipos SET tipobase='Lbl.Comprobantes.Recibo'
	WHERE (tipobase IS NULL OR tipobase='') AND tipo IN ('Lbl.Comprobantes.ReciboDeCobro', 'Lbl.Comprobantes.ReciboDeCobro');

UPDATE comprob_detalle SET total=precio*cantidad+iva WHERE total=0;


SET FOREIGN_KEY_CHECKS=1;
