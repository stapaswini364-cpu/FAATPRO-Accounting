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



const JournalEntryForm = ({ onCancel }) => {


    const [voucherNo] = useState(
        "JV-" + Date.now()
    );


    const [voucherDate,setVoucherDate] = useState(
        new Date()
        .toISOString()
        .split("T")[0]
    );


    const [referenceNo,setReferenceNo] = useState("");

    const [narration,setNarration] = useState("");


    const [ledgerList,setLedgerList] = useState([]);



    const [rows,setRows] = useState([

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

    },[]);





    const loadLedgers = async()=>{

        try{

            const data =
                await ledgerApi.getAll();


            setLedgerList(data);


        }
        catch(error){

            console.error(
                "Ledger Load Error",
                error
            );

        }

    };








    const addRow = ()=>{


        setRows([

            ...rows,

            {
                id:Date.now(),
                ledgerId:"",
                debit:"",
                credit:""
            }

        ]);

    };








    const removeRow=(id)=>{


        if(rows.length<=2){

            alert(
                "Minimum two rows required"
            );

            return;

        }


        setRows(
            rows.filter(
                row=>row.id!==id
            )
        );

    };









    const updateRow=(id,field,value)=>{


        setRows(

            rows.map(row=>{


                if(row.id===id){


                    if(field==="debit"){

                        return {

                            ...row,

                            debit:value,

                            credit:""

                        };

                    }



                    if(field==="credit"){

                        return {

                            ...row,

                            credit:value,

                            debit:""

                        };

                    }



                    return {

                        ...row,

                        [field]:value

                    };

                }



                return row;


            })

        );


    };









    const totalDebit = rows.reduce(

        (sum,row)=>

        sum + Number(row.debit || 0),

        0

    );




    const totalCredit = rows.reduce(

        (sum,row)=>

        sum + Number(row.credit || 0),

        0

    );



    const difference =
        totalDebit-totalCredit;









    const handleSave = async()=>{


        if(
            rows.some(
                row=>!row.ledgerId
            )
        ){

            alert(
                "Please select ledger"
            );

            return;

        }





        if(totalDebit<=0 || totalCredit<=0){

            alert(
                "Debit and Credit required"
            );

            return;

        }






        if(difference!==0){

            alert(
                "Debit and Credit must be equal"
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

            rows.map(row=>(


                {

                    ledgerId:
                        row.ledgerId,


                    debit:
                        Number(
                            row.debit || 0
                        ),


                    credit:
                        Number(
                            row.credit || 0
                        ),


                    narration

                }


            ))

        };






        console.log(
            "Journal Payload",
            payload
        );





        try{


            await journalEntryApi.create(
                payload
            );



            alert(
                "Journal Entry Saved Successfully"
            );



            onCancel();


        }
        catch(error){


            console.error(
                error
            );


            alert(
                "Save Failed"
            );


        }


    };









    return (

        <Box>


            <Grid
                container
                spacing={2}
            >


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







            <Paper
                sx={{
                    mt:3,
                    p:2
                }}
            >


            {
                rows.map(row=>(


                <Grid

                    container

                    spacing={2}

                    mb={2}

                    key={row.id}

                    alignItems="center"

                >



                    <Grid item xs={12} md={5}>


                        <TextField

                            select

                            fullWidth

                            label="Ledger"

                            value={
                                row.ledgerId
                            }


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

                                    key={
                                        ledger.id
                                    }

                                    value={
                                        ledger.id
                                    }

                                >

                                    {
                                        ledger.name
                                    }

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

                            value={
                                row.debit
                            }


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

                            value={
                                row.credit
                            }


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
                                ()=>removeRow(
                                    row.id
                                )
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

                startIcon={
                    <AddIcon/>
                }

                onClick={addRow}

            >

                Add Row

            </Button>








            <Paper

                sx={{
                    mt:3,
                    p:2
                }}

            >


                <Typography>
                    Total Debit : ₹ {totalDebit}
                </Typography>


                <Typography>
                    Total Credit : ₹ {totalCredit}
                </Typography>


                <Typography
                    color={
                        difference===0
                        ?
                        "green"
                        :
                        "error"
                    }
                >

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

                    startIcon={
                        <SaveIcon/>
                    }

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