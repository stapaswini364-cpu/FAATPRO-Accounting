import api from "./axios";


const accountHeadApi = {


    getAll: async()=>{

        const response =
            await api.get("/AccountHead");

        return response.data;

    },


    getById: async(id)=>{

        const response =
            await api.get(`/AccountHead/${id}`);

        return response.data;

    },


    create: async(data)=>{

        const response =
            await api.post(
                "/AccountHead",
                data
            );

        return response.data;

    },


    update: async(id,data)=>{

        const response =
            await api.put(
                `/AccountHead/${id}`,
                data
            );

        return response.data;

    },


    delete: async(id)=>{

        const response =
            await api.delete(
                `/AccountHead/${id}`
            );

        return response.data;

    }


};


export default accountHeadApi;