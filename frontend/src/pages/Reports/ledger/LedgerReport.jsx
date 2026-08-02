import { useEffect, useState } from "react";

import {
    Box,
    Button,
    MenuItem,
    Paper,
    Stack,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    TextField,
    Typography
} from "@mui/material";


import ledgerApi from "../../../api/ledgerApi";



const LedgerReport = () => {


    const [ledgerList,setLedgerList] =
        useState([]);


    const [ledgerId,setLedgerId] =
        useState("");


    const [ledgerData,setLedgerData] =
        useState(null);



    // ================= LOAD LEDGERS =================

    const loadLedgers = async()=>{


        try{


            const data =
                await ledgerApi.getAll();



            setLedgerList(

                Array.isArray(data)

                ?

                data

                :

                data.data || []

            );


        }
        catch(error){

            console.error(
                "Ledger Load Error",
                error
            );

        }


    };





    // ================= LOAD REPORT =================


    const loadLedgerReport = async()=>{


        if(!ledgerId)
        {
            alert(
                "Please select ledger"
            );

            return;
        }



        try{


            const data =
                await ledgerApi.getById(
                    ledgerId
                );



            console.log(
                "LEDGER REPORT RESPONSE",
                data
            );



            setLedgerData(data);



        }
        catch(error){


            console.error(
                "Ledger Report Error",
                error
            );


        }


    };







    useEffect(()=>{


        loadLedgers();


    },[]);








    const amount=(value)=>{


        return new Intl.NumberFormat(

            "en-IN",

            {

                style:"currency",

                currency:"INR"

            }

        )
        .format(
            Number(value || 0)
        );


    };







    const transactions =

        ledgerData?.transactions

        ||

        ledgerData?.details

        ||

        [];





    const ledgerName =

        ledgerData?.ledgerName

        ||

        ledgerData?.name

        ||

        ledgerData?.ledger?.name

        ||

        "-";






    const openingBalance =

        ledgerData?.openingBalance

        ||

        0;





    const closingBalance =

        ledgerData?.closingBalance

        ??

        (
            openingBalance

            +

            transactions.reduce(

                (sum,row)=>

                sum +

                Number(row.debit || 0)

                -

                Number(row.credit || 0),

                0

            )

        );









return (


<Box sx={{p:3}}>


<Paper sx={{p:3}}>



<Typography

variant="h5"

fontWeight={600}

mb={3}

>

Ledger Report

</Typography>







<Stack

direction="row"

spacing={2}

mb={3}

>



<TextField


select


label="Select Ledger"


value={ledgerId}


onChange={

e=>

setLedgerId(
    e.target.value
)

}


sx={{

minWidth:300

}}


>



{

ledgerList.map(

ledger=>(


<MenuItem

key={ledger.id}

value={ledger.id}

>


{
ledger.name
||
ledger.ledgerName
}


</MenuItem>


)

)

}



</TextField>






<Button

variant="contained"

onClick={loadLedgerReport}

>

Show Report

</Button>



</Stack>









{

ledgerData &&


<>


<Typography>

<b>Ledger Name:</b>{" "}

{ledgerName}

</Typography>




<Typography>

<b>Opening Balance:</b>{" "}

{amount(openingBalance)}

</Typography>








<Table

sx={{

mt:3

}}

>



<TableHead>


<TableRow>


<TableCell>
Date
</TableCell>


<TableCell>
Voucher No
</TableCell>


<TableCell>
Narration
</TableCell>


<TableCell align="right">
Debit
</TableCell>


<TableCell align="right">
Credit
</TableCell>


</TableRow>


</TableHead>







<TableBody>


{


transactions.length > 0

?


transactions.map(

(row,index)=>(


<TableRow

key={index}

>


<TableCell>

{
row.date
}

</TableCell>




<TableCell>

{
row.voucherNo
||
row.voucherNumber
||
"-"
}

</TableCell>





<TableCell>

{
row.narration
||
"-"
}

</TableCell>





<TableCell align="right">


{
amount(
row.debit
)
}


</TableCell>





<TableCell align="right">


{
amount(
row.credit
)
}


</TableCell>





</TableRow>


)


)


:


<TableRow>

<TableCell colSpan={5} align="center">

No Transactions Found

</TableCell>

</TableRow>


}



</TableBody>


</Table>







<Typography

mt={3}

fontWeight="bold"

>


Closing Balance :

{" "}

{
amount(
closingBalance
)
}



</Typography>



</>


}




</Paper>


</Box>


);


};


export default LedgerReport;