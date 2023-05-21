export interface Trabajador {
  idUsuario?:          number;
  documentoIdentidad: string;
  nombres:            string;
  telefono:           string;
  correo:             string;
  ciudad:             string;
  fechaRegistro?:      Date;
}
