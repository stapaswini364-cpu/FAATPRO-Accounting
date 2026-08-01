import api from "./axios";


const accountGroupApi = {


    getAll: async()=>{

        const response =
            await api.get("/AccountGroup");

        return response.data;

    },


    getById: async(id)=>{

        const response =
            await api.get(`/AccountGroup/${id}`);

        return response.data;

    },


    create: async(data)=>{

        const response =
            await api.post(
                "/AccountGroup",
                data
            );

        return response.data;

    },


    update: async(id,data)=>{

        const response =
            await api.put(
                `/AccountGroup/${id}`,
                data
            );

        return response.data;

    },


    delete: async(id)=>{

        const response =
            await api.delete(
                `/AccountGroup/${id}`
            );

        return response.data;

    }


};


export default accountGroupApi;