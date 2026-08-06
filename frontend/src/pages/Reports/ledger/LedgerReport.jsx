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

import {
    getLedgerReport
} from "../../../api/reportApi";



const LedgerReport = () => {


    const [ledgerList,setLedgerList] =
        useState([]);


    const [ledgerId,setLedgerId] =
        useState("");


    const [ledgerData,setLedgerData] =
        useState([]);



    // LOAD LEDGER LIST

    const loadLedgers = async()=>{

        try{

            const response =
                await ledgerApi.getAll();


            setLedgerList(

                Array.isArray(response)

                ?

                response

                :

                response.data || []

            );

        }
        catch(error){

            console.error(
                "Ledger Load Error",
                error
            );

        }

    };





    // LOAD STATEMENT


    const loadLedgerReport = async()=>{


        if(!ledgerId)
        {
            alert(
                "Select Ledger"
            );

            return;
        }


        try{


            const response =
                await getLedgerReport(
                    ledgerId
                );


            console.log(
                "Ledger Statement",
                response.data
            );


            setLedgerData(
                response.data
            );


        }
        catch(error){

            console.error(
                "Ledger Statement Error",
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





return (

<Box sx={{p:3}}>


<Paper sx={{p:3}}>


<Typography
variant="h5"
fontWeight="bold"
mb={3}
>
Ledger Statement
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
    e=>setLedgerId(e.target.value)
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
Show
</Button>



</Stack>





<Table>


<TableHead>

<TableRow>

<TableCell>
Date
</TableCell>


<TableCell>
Ledger
</TableCell>


<TableCell align="right">
Debit
</TableCell>


<TableCell align="right">
Credit
</TableCell>


<TableCell align="right">
Balance
</TableCell>


<TableCell>
Narration
</TableCell>


</TableRow>

</TableHead>




<TableBody>


{

ledgerData.length > 0

?


ledgerData.map(

(row)=>(


<TableRow key={row.id}>


<TableCell>

{
new Date(
row.postingDate
)
.toLocaleDateString()
}

</TableCell>



<TableCell>

{
row.ledgerName
}

</TableCell>



<TableCell align="right">

{
amount(row.debit)
}

</TableCell>



<TableCell align="right">

{
amount(row.credit)
}

</TableCell>



<TableCell align="right">

{
amount(row.balance)
}

</TableCell>



<TableCell>

{
row.narration || "-"
}

</TableCell>



</TableRow>


)

)


:


<TableRow>

<TableCell
colSpan={6}
align="center"
>

No Data

</TableCell>

</TableRow>


}



</TableBody>


</Table>



</Paper>


</Box>

);


};


export default LedgerReport;