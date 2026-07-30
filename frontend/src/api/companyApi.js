import axios from "./axios";


const companyApi = {

    getAll: async () => {
        const response = await axios.get("/Company");
        return response.data;
    },


    getById: async (id) => {
        const response = await axios.get(`/Company/${id}`);
        return response.data;
    },


    create: async (data) => {
        const response = await axios.post("/Company", data);
        return response.data;
    },


    update: async (id, data) => {
        const response = await axios.put(`/Company/${id}`, data);
        return response.data;
    },


    remove: async (id) => {
        const response = await axios.delete(`/Company/${id}`);
        return response.data;
    }

};


export default companyApi;