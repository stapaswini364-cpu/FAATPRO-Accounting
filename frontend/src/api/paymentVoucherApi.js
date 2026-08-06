import axios from "./axios";


const paymentVoucherApi = {


    create: async(data)=>{

        const response =
            await axios.post(
                "/PaymentVoucher",
                data
            );

        return response.data;

    }


};


export default paymentVoucherApi;