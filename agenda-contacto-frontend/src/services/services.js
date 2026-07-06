import axios from "axios";

const API_URL = "http://localhost:5029/api/contactos";

export const traerContactos = () => {
    return axios.get(API_URL);
}
export const crearContactos = (contacto) => {
    return axios.post(API_URL, contacto)
}
export const actualizarContactos = (id, contacto) => {
    return axios.put(`${API_URL}/${id}`, contacto)
}
export const eliminarContactos = (id) => {
    return axios.delete(`${API_URL}/${id}`)
}