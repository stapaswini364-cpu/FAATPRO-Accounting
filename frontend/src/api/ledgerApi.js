import api from "./axios";


const ledgerApi = {


    getAll: async()=>{

        const response =
            await api.get("/Ledger");

        return response.data;

    },



    getById: async(id)=>{

        const response =
            await api.get(`/Ledger/${id}`);

        return response.data;

    },



    create: async(data)=>{

        const response =
            await api.post(
                "/Ledger",
                data
            );

        return response.data;

    },



    update: async(id,data)=>{

        const response =
            await api.put(
                `/Ledger/${id}`,
                data
            );

        return response.data;

    },



    delete: async(id)=>{

        const response =
            await api.delete(
                `/Ledger/${id}`
            );

        return response.data;

    }


};


export default ledgerApi;