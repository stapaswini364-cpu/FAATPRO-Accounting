import React from "react";

import {
    Box,
    Button,
    Dialog,
    DialogContent,
    Stack,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Typography
} from "@mui/material";

import PrintIcon from "@mui/icons-material/Print";



const JournalEntryPrint = ({
    open,
    data,
    onClose
}) => {



    if(!data)
        return null;





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






    const handlePrint=()=>{


        window.print();


    };








    const totalDebit =

        data.details?.reduce(
            (sum,row)=>
            sum + Number(row.debit || 0),
            0
        ) || 0;





    const totalCredit =

        data.details?.reduce(
            (sum,row)=>
            sum + Number(row.credit || 0),
            0
        ) || 0;









    return (


        <Dialog

            open={open}

            onClose={onClose}

            maxWidth="md"

            fullWidth

        >



            <DialogContent>



                <Box
                    id="print-area"
                    sx={{
                        p:3
                    }}
                >



                    <Typography

                        variant="h4"

                        textAlign="center"

                        fontWeight="bold"

                    >

                        FAATPRO


                    </Typography>





                    <Typography

                        variant="h6"

                        textAlign="center"

                        mb={3}

                    >

                        JOURNAL VOUCHER


                    </Typography>









                    <Stack spacing={1}>


                        <Typography>

                            <b>Voucher No:</b>{" "}

                            {data.voucherNo}

                        </Typography>





                        <Typography>

                            <b>Date:</b>{" "}

                            {
                                formatDate(
                                    data.voucherDate
                                )
                            }

                        </Typography>





                        <Typography>

                            <b>Reference No:</b>{" "}

                            {
                                data.referenceNo || "-"
                            }

                        </Typography>





                        <Typography>

                            <b>Narration:</b>{" "}

                            {
                                data.narration || "-"
                            }

                        </Typography>


                    </Stack>









                    <Table

                    sx={{
                        mt:3
                    }}

                    >


                        <TableHead>


                            <TableRow>


                                <TableCell>

                                    <b>Ledger</b>

                                </TableCell>



                                <TableCell align="right">

                                    <b>Debit</b>

                                </TableCell>



                                <TableCell align="right">

                                    <b>Credit</b>

                                </TableCell>


                            </TableRow>


                        </TableHead>







                        <TableBody>


                        {

                            data.details?.map(
                                (row,index)=>(


                                <TableRow
                                key={index}
                                >



                                    <TableCell>

                                    {

                                        row.ledgerName ||

                                        row.ledger?.name ||

                                        "Ledger"

                                    }

                                    </TableCell>





                                    <TableCell align="right">

                                        {
                                            formatAmount(
                                                row.debit
                                            )
                                        }


                                    </TableCell>





                                    <TableCell align="right">

                                        {
                                            formatAmount(
                                                row.credit
                                            )
                                        }


                                    </TableCell>



                                </TableRow>


                                )

                            )

                        }







                        <TableRow>


                            <TableCell>

                                <b>Total</b>

                            </TableCell>



                            <TableCell align="right">

                                <b>

                                {
                                    formatAmount(
                                        totalDebit
                                    )
                                }

                                </b>


                            </TableCell>



                            <TableCell align="right">

                                <b>

                                {
                                    formatAmount(
                                        totalCredit
                                    )
                                }

                                </b>


                            </TableCell>



                        </TableRow>



                        </TableBody>


                    </Table>








                    <Stack

                    direction="row"

                    justifyContent="space-between"

                    mt={6}

                    >



                        <Typography>

                            Prepared By: Admin

                        </Typography>





                        <Typography>

                            Authorized Signatory

                        </Typography>



                    </Stack>







                </Box>






                <Stack

                direction="row"

                spacing={2}

                mt={3}

                >


                    <Button

                    variant="contained"

                    startIcon={
                        <PrintIcon/>
                    }

                    onClick={handlePrint}

                    >

                        Print


                    </Button>





                    <Button

                    variant="outlined"

                    onClick={onClose}

                    >

                        Close


                    </Button>


                </Stack>





            </DialogContent>




        </Dialog>


    );


};


export default JournalEntryPrint;