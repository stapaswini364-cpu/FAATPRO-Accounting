import axios from "./axios";


const journalEntryApi = {


    getAll: async () => {

        const response =
            await axios.get("/JournalEntry");

        return response.data;

    },


    getById: async (id) => {

        const response =
            await axios.get(
                `/JournalEntry/${id}`
            );

        return response.data;

    },


    create: async (data) => {

        const response =
            await axios.post(
                "/JournalEntry",
                data
            );

        return response.data;

    },


    delete: async (id) => {

        const response =
            await axios.delete(
                `/JournalEntry/${id}`
            );

        return response.data;

    }


};


export default journalEntryApi;