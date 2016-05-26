SET FOREIGN_KEY_CHECKS=0;

UPDATE documentos_tipos SET tipobase='Lbl.Comprobantes.ComprobanteFacturable'
	WHERE tipo IN ('Lbl.Comprobantes.Factura', 'Lbl.Comprobantes.NotaDeCredito', 'Lbl.Comprobantes.NotaDeDebito', 'Lbl.Comprobantes.Ticket');

UPDATE documentos_tipos SET tipobase='Lbl.Comprobantes.Recibo'
	WHERE tipo IN ('Lbl.Comprobantes.ReciboDeCobro', 'Lbl.Comprobantes.ReciboDePago');

UPDATE personas SET saldo_ctacte = (SELECT SUM(importe)  FROM ctacte WHERE ctacte.id_cliente=personas.id_persona)
	WHERE personas.id_persona IN (SELECT DISTINCT id_cliente FROM ctacte);

UPDATE "sys_permisos_objetos" SET "clase"='Lazaro\\Base\\Persona' WHERE "tipo"='Lbl.Personas.Persona';
UPDATE "sys_permisos_objetos" SET "clase"='Global' WHERE "tipo"='Global';

SET FOREIGN_KEY_CHECKS=1;