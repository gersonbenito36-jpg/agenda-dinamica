import axios from "axios";

const API_URL = "http://localhost:3000/api/contactos";

export const taerContactos = () => {
    return axios.get(API_URL);
}
export const crearContactos = () => {
    return axios.post(API_URL);
}
export const actualizarContactos = () => {
    return axios.put(API_URL);
}
export const eliminarContactos = () => {
    return axios.delete(API_URL);
}