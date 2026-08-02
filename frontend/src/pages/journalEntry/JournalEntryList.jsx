import { useEffect, useState } from "react";

import JournalEntryPrint from "./components/JournalEntryPrint";

import {
    Box,
    Button,
    CircularProgress,
    IconButton,
    Paper,
    Stack,
    Typography,
    Snackbar,
    Alert
} from "@mui/material";


import {
    DataGrid
} from "@mui/x-data-grid";


import RefreshIcon from "@mui/icons-material/Refresh";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import VisibilityIcon from "@mui/icons-material/Visibility";
import PrintIcon from "@mui/icons-material/Print";


import journalEntryApi from "../../api/journalEntryApi";

import JournalEntryView 
from "./components/JournalEntryView";



const JournalEntryList = ({
    onEdit
}) => {


    const [rows,setRows] =
        useState([]);


    const [loading,setLoading] =
        useState(false);


    const [message,setMessage] =
        useState("");


    const [openSnackbar,setOpenSnackbar] =
        useState(false);



    const [viewData,setViewData] =
        useState(null);


    const [viewOpen,setViewOpen] =
        useState(false);



    const [printData,setPrintData] =
        useState(null);


    const [printOpen,setPrintOpen] =
        useState(false);





    const formatDate=(date)=>{


        if(!date)
            return "-";


        return new Date(date)
        .toLocaleDateString("en-IN");


    };





    const formatAmount=(amount)=>{


        return new Intl.NumberFormat(
            "en-IN",
            {
                style:"currency",
                currency:"INR"
            }

        )
        .format(amount || 0);


    };







    const loadJournalEntries=async()=>{


        try{


            setLoading(true);



            const response =
                await journalEntryApi.getAll();



            const data =

                Array.isArray(response)

                ?

                response

                :

                response.data || [];





            setRows(

                data.map(item=>(

                    {

                        id:item.id,


                        voucherNo:
                        item.voucherNo || "-",



                        date:
                        formatDate(
                            item.voucherDate
                        ),



                        narration:
                        item.narration || "-",



                        debit:
                        item.totalDebit || 0,



                        credit:
                        item.totalCredit || 0

                    }

                ))

            );



        }
        catch(error){


            console.error(
                "Journal Load Error",
                error
            );


            setMessage(
                "Journal Load Failed"
            );


            setOpenSnackbar(true);


        }
        finally{


            setLoading(false);


        }


    };







    useEffect(()=>{


        loadJournalEntries();


    },[]);










    const handleDelete=async(id)=>{


        const confirm =
            window.confirm(
                "Delete this voucher?"
            );



        if(!confirm)
            return;




        try{


            await journalEntryApi.delete(id);



            setMessage(
                "Voucher Deleted Successfully"
            );


            setOpenSnackbar(true);



            loadJournalEntries();



        }
        catch(error){


            console.error(error);



            setMessage(
                "Delete Failed"
            );


            setOpenSnackbar(true);



        }


    };









    const handleView=async(id)=>{


        try{


            const data =
                await journalEntryApi.getById(id);



            setViewData(data);



            setViewOpen(true);



        }
        catch(error){


            console.error(
                "View Error",
                error
            );


        }


    };









    const handlePrint=async(id)=>{


        try{


            const data =
                await journalEntryApi.getById(id);



            setPrintData(data);



            setPrintOpen(true);



        }
        catch(error){


            console.error(
                "Print Error",
                error
            );


        }


    };









    const columns=[



        {
            field:"voucherNo",

            headerName:"Voucher No",

            width:180

        },




        {
            field:"date",

            headerName:"Date",

            width:130

        },




        {
            field:"narration",

            headerName:"Narration",

            width:250

        },




        {
            field:"debit",

            headerName:"Debit",

            width:150,


            renderCell:(params)=>

                formatAmount(
                    params.value
                )


        },




        {
            field:"credit",

            headerName:"Credit",

            width:150,


            renderCell:(params)=>

                formatAmount(
                    params.value
                )


        },






        {

            field:"actions",

            headerName:"Actions",

            width:230,



            renderCell:(params)=>(


                <Stack
                    direction="row"
                >



                    <IconButton

                        color="primary"

                        title="View"

                        onClick={()=>{

                            handleView(
                                params.row.id
                            );

                        }}

                    >

                        <VisibilityIcon/>

                    </IconButton>








                    <IconButton

                        color="success"

                        title="Edit"

                        onClick={()=>{

                            onEdit(
                                params.row.id
                            );

                        }}

                    >

                        <EditIcon/>

                    </IconButton>








                    <IconButton

                        color="info"

                        title="Print"

                        onClick={()=>{

                            handlePrint(
                                params.row.id
                            );

                        }}

                    >

                        <PrintIcon/>

                    </IconButton>








                    <IconButton

                        color="error"

                        title="Delete"

                        onClick={()=>{

                            handleDelete(
                                params.row.id
                            );

                        }}

                    >

                        <DeleteIcon/>

                    </IconButton>



                </Stack>


            )


        }


    ];









    return (


        <Box sx={{p:3}}>



            <Paper sx={{p:3}}>



                <Stack

                    direction="row"

                    justifyContent="space-between"

                    mb={3}

                >



                    <Typography

                        variant="h5"

                        fontWeight={600}

                    >

                        Journal Entries


                    </Typography>






                    <Button

                        variant="outlined"

                        startIcon={
                            <RefreshIcon/>
                        }

                        onClick={
                            loadJournalEntries
                        }

                    >

                        Refresh


                    </Button>




                </Stack>









                {

                    loading


                    ?



                    <Box

                        display="flex"

                        justifyContent="center"

                        p={5}

                    >

                        <CircularProgress/>


                    </Box>



                    :




                    <DataGrid


                        rows={rows}


                        columns={columns}


                        autoHeight



                        pageSizeOptions={[
                            5,
                            10,
                            25
                        ]}



                        initialState={{

                            pagination:{

                                paginationModel:{

                                    pageSize:10,

                                    page:0

                                }

                            }

                        }}



                        disableRowSelectionOnClick


                    />


                }





            </Paper>










            <Snackbar

                open={openSnackbar}

                autoHideDuration={3000}

                onClose={()=>{

                    setOpenSnackbar(false);

                }}

            >


                <Alert severity="success">

                    {message}


                </Alert>


            </Snackbar>









            <JournalEntryView


                open={viewOpen}


                data={viewData}


                onClose={()=>{

                    setViewOpen(false);

                }}


            />









            <JournalEntryPrint


                open={printOpen}


                data={printData}


                onClose={()=>{

                    setPrintOpen(false);

                }}


            />




        </Box>


    );


};


export default JournalEntryList;