<script setup>
import { ref } from 'vue';
import { watch } from 'vue';
import { crearContactos } from '../services/services.js';
import { actualizarContactos} from '../services/services.js';

const propiedades =defineProps({  //está vinculado con el watch
    contacto: Object
})

const emit = defineEmits(['cerrar', 'contactoCreado'])
const nombre = ref('')
const telefono = ref('')
const correo = ref('')

watch(() => propiedades.contacto, (nuevoContacto) => {
    if (nuevoContacto){
        nombre.value = nuevoContacto.nombre
        telefono.value = nuevoContacto.telefono
        correo.value = nuevoContacto.correo
    } else{
        nombre.value = ''
        telefono.value = ''
        correo.value = ''
    }
}, {immediate : true })

const registrarContacto = async() =>{
    if (propiedades.contacto)  {
        await actualizarContactos (propiedades.contacto.id, {
            id: propiedades.contacto.id,
            nombre: nombre.value, 
            telefono: telefono.value,
            correo: correo.value
        })

       
    } else{
        await crearContactos({
            nombre: nombre.value,
            telefono: telefono.value,
            correo: correo.value
        })
    }
    emit('contactoCreado')
    emit('cerrar')
}
</script>


<template>
<div class="fixed inset-0 bg-slate-800 bg-opacity-20 flex items-center justify-center">
    <form 
    class="bg-white rounded-xl w-96 p-10  flex flex-col gap-6">
    <div class="flex justify-end"> 
    <button type="button" class="text-red-500 " @click="emit('cerrar')">Cerrar</button>
    </div>
    
        <label for="nombre" class="font-bold text-md text-red-500">Nombre de contacto</label>
        <input v-model="nombre" type="text"  class="font-bold text-md text-red-500 " placeholder="Nombre">

        <label for="email">Email contacto</label>
        <input v-model="correo" type="email" class="font-bold text-md text-red-500" placeholder="Email">

        <label for="telefono" >Telefono</label>
        <input v-model="telefono" type="telefono"  class="font-bold text-md text-red-500" placeholder="Teléfono">
        
        <div class="flex flex-row justify-center">
            <button type="button" @click="registrarContacto" class=" bg-sky-400 m-2 p-2 w-full m-0 rounded-xl cursor-pointer hover:scale-110 transition-transform hover:bg-sky-600">Registrar contacto</button>
        </div>
    </form>
</div>
</template>