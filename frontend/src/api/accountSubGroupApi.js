import api from "./axios";


const accountSubGroupApi = {


    getAll: async()=>{

        const response =
            await api.get("/AccountSubGroup");

        return response.data;

    },


    getById: async(id)=>{

        const response =
            await api.get(`/AccountSubGroup/${id}`);

        return response.data;

    },


    create: async(data)=>{

        const response =
            await api.post(
                "/AccountSubGroup",
                data
            );

        return response.data;

    },


    update: async(id,data)=>{

        const response =
            await api.put(
                `/AccountSubGroup/${id}`,
                data
            );

        return response.data;

    },


    delete: async(id)=>{

        const response =
            await api.delete(
                `/AccountSubGroup/${id}`
            );

        return response.data;

    }


};


export default accountSubGroupApi;