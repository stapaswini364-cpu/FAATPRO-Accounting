import {
    useState,
    useEffect
} from "react";


import {
    Box,
    Button,
    TextField,
    MenuItem,
    Stack,
    Typography
}
from "@mui/material";


import ledgerApi from "../../../api/ledgerApi";
import paymentVoucherApi from "../../../api/paymentVoucherApi";


const PaymentVoucherForm = ()=>{


const [ledgers,setLedgers]=useState([]);


const [form,setForm]=useState({

    voucherDate:
        new Date()
        .toISOString()
        .substring(0,16),

    cashBankLedgerId:"",

    expenseLedgerId:"",

    amount:"",

    narration:"",

    companyId:
    "cc94551b-6662-4bb3-964f-c8073ee11751",

    financialYearId:
    "6513fb3e-e4ab-4f90-92ba-ea04d909ac77"

});




useEffect(()=>{


loadLedgers();


},[]);




const loadLedgers=async()=>{


try{


const data =
await ledgerApi.getAll();


setLedgers(
Array.isArray(data)
?data
:data.data || []
);


}
catch(error){

console.log(error);

}


};





const handleChange=(e)=>{


setForm({

...form,

[e.target.name]:
e.target.value

});


};





const saveVoucher=async()=>{


try{


await paymentVoucherApi.create({

...form,

amount:
Number(form.amount)

});


alert(
"Payment Voucher Created"
);


}
catch(error){

console.log(error);

alert(
"Voucher Failed"
);

}


};




return (

<Box>


<Typography
variant="h5"
mb={3}
>
Payment Voucher
</Typography>



<Stack spacing={2}>


<TextField

type="datetime-local"

name="voucherDate"

value={form.voucherDate}

onChange={handleChange}

/>




<TextField

select

label="Expense Ledger"

name="expenseLedgerId"

value={form.expenseLedgerId}

onChange={handleChange}

>


{
ledgers.map(x=>(

<MenuItem
key={x.id}
value={x.id}
>

{x.name}

</MenuItem>

))

}


</TextField>






<TextField

select

label="Cash / Bank Ledger"

name="cashBankLedgerId"

value={form.cashBankLedgerId}

onChange={handleChange}

>


{
ledgers.map(x=>(

<MenuItem
key={x.id}
value={x.id}
>

{x.name}

</MenuItem>

))

}


</TextField>







<TextField

label="Amount"

name="amount"

value={form.amount}

onChange={handleChange}

/>





<TextField

label="Narration"

name="narration"

value={form.narration}

onChange={handleChange}

/>






<Button

variant="contained"

onClick={saveVoucher}

>

Save Payment Voucher

</Button>



</Stack>


</Box>


);


};


export default PaymentVoucherForm;