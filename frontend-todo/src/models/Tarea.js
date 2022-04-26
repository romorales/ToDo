const { v4: uuidv4 } = require('uuid');
export default class Tarea {
  constructor(nombre, estado) {
    this.id = uuidv4();
    this.nombre = nombre;
    this.estado = estado;
  }
}