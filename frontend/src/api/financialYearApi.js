import axios from "./axios";


const financialYearApi = {


    getAll: async () => {

        const response =
            await axios.get("/FinancialYear");

        return response.data;

    },



    getById: async (id) => {

        const response =
            await axios.get(`/FinancialYear/${id}`);

        return response.data;

    },



    create: async (data) => {

        const response =
            await axios.post(
                "/FinancialYear",
                data
            );

        return response.data;

    },



    update: async (id, data) => {

        const response =
            await axios.put(
                `/FinancialYear/${id}`,
                data
            );

        return response.data;

    },



    remove: async (id) => {

        const response =
            await axios.delete(
                `/FinancialYear/${id}`
            );

        return response.data;

    }


};


export default financialYearApi;