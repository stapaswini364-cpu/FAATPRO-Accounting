import axios from "./axios";


const journalEntryApi = {


    // ================= GET ALL =================

    getAll: async () => {

        const response =
            await axios.get(
                "/JournalEntry"
            );

        return response.data;

    },



    // ================= GET BY ID =================

    getById: async (id) => {

        const response =
            await axios.get(
                `/JournalEntry/${id}`
            );

        return response.data;

    },



    // ================= CREATE =================

    create: async (data) => {

        const response =
            await axios.post(
                "/JournalEntry",
                data
            );

        return response.data;

    },



    // ================= UPDATE =================

    update: async (id, data) => {

        const response =
            await axios.put(
                `/JournalEntry/${id}`,
                data
            );

        return response.data;

    },



    // ================= DELETE =================

    delete: async (id) => {

        const response =
            await axios.delete(
                `/JournalEntry/${id}`
            );

        return response.data;

    }


};


export default journalEntryApi;