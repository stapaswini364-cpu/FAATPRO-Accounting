import { useEffect, useState } from "react";

import {
    Box,
    Button,
    Grid,
    IconButton,
    MenuItem,
    Paper,
    Stack,
    TextField,
    Typography
} from "@mui/material";

import AddIcon from "@mui/icons-material/Add";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save";

import journalEntryApi from "../../../api/journalEntryApi";
import ledgerApi from "../../../api/ledgerApi";


const JournalEntryForm = ({
    onCancel,
    editId = null
}) => {


    const [voucherNo,setVoucherNo] =
        useState("JV-" + Date.now());


    const [voucherDate,setVoucherDate] =
        useState(
            new Date()
            .toISOString()
            .split("T")[0]
        );


    const [referenceNo,setReferenceNo] =
        useState("");


    const [narration,setNarration] =
        useState("");


    const [isEdit,setIsEdit] =
        useState(false);


    const [ledgerList,setLedgerList] =
        useState([]);



    const [rows,setRows] =
        useState([

            {
                id:1,
                ledgerId:"",
                debit:"",
                credit:""
            },

            {
                id:2,
                ledgerId:"",
                debit:"",
                credit:""
            }

        ]);





    useEffect(()=>{

        loadLedgers();

        if(editId)
        {
            loadJournalEntry();
        }

    },[]);






    // ============================
    // LOAD LEDGER
    // ============================

    const loadLedgers = async()=>{

        try{

            const response =
                await ledgerApi.getAll();


            console.log(
                "LEDGER RESPONSE",
                response
            );


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
                "Ledger Error",
                error
            );

        }

    };






    // ============================
    // LOAD EDIT
    // ============================

    const loadJournalEntry = async()=>{

        try{

            const data =
                await journalEntryApi.getById(editId);


            setVoucherNo(data.voucherNo);

            setVoucherDate(
                data.voucherDate.split("T")[0]
            );

            setReferenceNo(
                data.referenceNo || ""
            );

            setNarration(
                data.narration || ""
            );


            setRows(

                data.details.map(
                    (x,index)=>({

                        id:index+1,

                        ledgerId:String(
                            x.ledgerId
                        ),

                        debit:x.debit,

                        credit:x.credit

                    })

                )

            );


            setIsEdit(true);


        }
        catch(error){

            console.error(error);

        }

    };







    // ============================
    // ADD ROW
    // ============================

    const addRow=()=>{

        setRows(prev=>[

            ...prev,

            {
                id:Date.now(),
                ledgerId:"",
                debit:"",
                credit:""
            }

        ]);

    };







    // ============================
    // DELETE ROW
    // ============================

    const removeRow=(id)=>{


        if(rows.length<=2)
        {
            alert(
                "Minimum two rows required"
            );

            return;
        }


        setRows(
            prev =>
            prev.filter(
                x=>x.id!==id
            )
        );


    };







    // ============================
    // UPDATE ROW
    // ============================

    const updateRow=(id,field,value)=>{


        setRows(prev =>

            prev.map(row=>{


                if(row.id!==id)
                    return row;



                if(field==="debit")
                {

                    return {

                        ...row,

                        debit:value,

                        credit:""

                    };

                }



                if(field==="credit")
                {

                    return {

                        ...row,

                        credit:value,

                        debit:""

                    };

                }




                if(field==="ledgerId")
                {

                    return {

                        ...row,

                        ledgerId:String(value)

                    };

                }



                return row;


            })

        );


    };







    const totalDebit =
        rows.reduce(
            (sum,x)=>
            sum + Number(x.debit || 0),
            0
        );



    const totalCredit =
        rows.reduce(
            (sum,x)=>
            sum + Number(x.credit || 0),
            0
        );



    const difference =
        totalDebit-totalCredit;








    // ============================
    // SAVE
    // ============================

    const handleSave=async()=>{


        if(rows.some(x=>!x.ledgerId))
        {

            alert(
                "Please select ledger"
            );

            return;

        }



        if(difference!==0)
        {

            alert(
                "Debit Credit not equal"
            );

            return;

        }





        const payload={


            voucherNo,

            voucherDate,

            referenceNo,

            narration,


            companyId:
            "00000000-0000-0000-0000-000000000001",


            financialYearId:
            "00000000-0000-0000-0000-000000000001",



            details:

            rows.map(x=>({

                ledgerId:String(x.ledgerId),

                debit:Number(x.debit || 0),

                credit:Number(x.credit || 0),

                narration

            }))


        };



        console.log(
            "FINAL PAYLOAD",
            payload
        );




        try{


            if(isEdit)
            {

                await journalEntryApi.update(
                    editId,
                    payload
                );

            }
            else
            {

                await journalEntryApi.create(
                    payload
                );

            }



            alert(
                "Journal Saved Successfully"
            );


            onCancel();


        }
        catch(error){

            console.error(
                "SAVE ERROR",
                error.response?.data || error
            );


            alert(
                "Save Failed"
            );


        }


    };









return (

<Box>


<Grid container spacing={2}>


<Grid item xs={12} md={3}>

<TextField
fullWidth
label="Voucher No"
value={voucherNo}
disabled
/>

</Grid>



<Grid item xs={12} md={3}>

<TextField
fullWidth
type="date"
label="Voucher Date"
InputLabelProps={{
shrink:true
}}
value={voucherDate}
onChange={
e=>setVoucherDate(
e.target.value
)
}
/>

</Grid>



<Grid item xs={12} md={3}>

<TextField
fullWidth
label="Reference No"
value={referenceNo}
onChange={
e=>setReferenceNo(
e.target.value
)
}
/>

</Grid>



<Grid item xs={12} md={3}>

<TextField
fullWidth
label="Narration"
value={narration}
onChange={
e=>setNarration(
e.target.value
)
}
/>

</Grid>


</Grid>





<Paper sx={{mt:3,p:2}}>


{
rows.map(row=>(


<Grid
container
spacing={2}
key={row.id}
mb={2}
>


<Grid item xs={12} md={5}>


<TextField
select
fullWidth
label="Ledger"
value={row.ledgerId}
onChange={
e=>
updateRow(
row.id,
"ledgerId",
e.target.value
)
}
>


{
ledgerList.map(
ledger=>(


<MenuItem
key={ledger.id}
value={String(ledger.id)}
>

{ledger.name}

</MenuItem>


)

)

}


</TextField>


</Grid>





<Grid item xs={12} md={3}>

<TextField
fullWidth
type="number"
label="Debit"
value={row.debit}
onChange={
e=>
updateRow(
row.id,
"debit",
e.target.value
)
}
/>

</Grid>





<Grid item xs={12} md={3}>

<TextField
fullWidth
type="number"
label="Credit"
value={row.credit}
onChange={
e=>
updateRow(
row.id,
"credit",
e.target.value
)
}
/>

</Grid>





<Grid item xs={12} md={1}>

<IconButton
color="error"
onClick={
()=>removeRow(row.id)
}
>

<DeleteIcon/>

</IconButton>

</Grid>


</Grid>


))
}



</Paper>





<Button
sx={{mt:2}}
variant="outlined"
startIcon={<AddIcon/>}
onClick={addRow}
>

Add Row

</Button>






<Paper sx={{mt:3,p:2}}>


<Typography>
Total Debit : ₹ {totalDebit}
</Typography>


<Typography>
Total Credit : ₹ {totalCredit}
</Typography>


<Typography>
Difference : ₹ {difference}
</Typography>


</Paper>






<Stack
direction="row"
spacing={2}
mt={3}
>


<Button
variant="contained"
startIcon={<SaveIcon/>}
onClick={handleSave}
>

Save Voucher

</Button>



<Button
variant="outlined"
onClick={onCancel}
>

Cancel

</Button>


</Stack>


</Box>

);


};


export default JournalEntryForm;