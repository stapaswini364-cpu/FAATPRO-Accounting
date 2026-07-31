import axios from "./axios";


const branchApi = {


    getAll: async()=>{

        return await axios.get("/Branch");

    },



    getById: async(id)=>{

        return await axios.get(
            `/Branch/${id}`
        );

    },



    create: async(data)=>{

        return await axios.post(
            "/Branch",
            data
        );

    },



    update: async(id,data)=>{

        return await axios.put(

            `/Branch/${id}`,

            data

        );

    },



    remove: async(id)=>{

        return await axios.delete(

            `/Branch/${id}`

        );

    }


};


export default branchApi;