import accountHeadApi from "./accountHeadApi";
import accountGroupApi from "./accountGroupApi";
import accountSubGroupApi from "./accountSubGroupApi";
import ledgerApi from "./ledgerApi";


const chartOfAccountsApi = {


    getTree: async () => {


        const heads =
            await accountHeadApi.getAll();


        const groups =
            await accountGroupApi.getAll();


        const subGroups =
            await accountSubGroupApi.getAll();


        const ledgers =
            await ledgerApi.getAll();



        return {

            heads,

            groups,

            subGroups,

            ledgers

        };


    }


};


export default chartOfAccountsApi;