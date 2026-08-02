import {
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    Button,
    Typography,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Paper,
    Stack
} from "@mui/material";

import PrintIcon from "@mui/icons-material/Print";



const JournalEntryView = ({
    open,
    onClose,
    data
}) => {



    if(!data)
        return null;



    const printVoucher=()=>{

        window.print();

    };



    const totalDebit =
        data.details?.reduce(
            (sum,x)=>
            sum + Number(x.debit || 0),
            0
        ) || 0;



    const totalCredit =
        data.details?.reduce(
            (sum,x)=>
            sum + Number(x.credit || 0),
            0
        ) || 0;





    return (


        <Dialog

        open={open}

        onClose={onClose}

        maxWidth="md"

        fullWidth

        >



            <DialogTitle>

                Journal Voucher


            </DialogTitle>






            <DialogContent>



                <Paper
                sx={{
                    p:3
                }}
                >



                    <Stack spacing={1}>


                        <Typography>

                            <b>Voucher No:</b>{" "}
                            {data.voucherNo}

                        </Typography>




                        <Typography>

                            <b>Date:</b>{" "}
                            {
                                new Date(
                                    data.voucherDate
                                )
                                .toLocaleDateString("en-IN")
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
                                    Ledger
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
                            data.details?.map(
                                (item,index)=>(


                                <TableRow key={index}>


                                    <TableCell>

                                        {
                                            item.ledgerName
                                            ||
                                            item.ledgerId
                                        }

                                    </TableCell>



                                    <TableCell align="right">

                                        ₹ {
                                            item.debit || 0
                                        }

                                    </TableCell>



                                    <TableCell align="right">

                                        ₹ {
                                            item.credit || 0
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
                                ₹ {totalDebit}
                                </b>

                            </TableCell>


                            <TableCell align="right">

                                <b>
                                ₹ {totalCredit}
                                </b>

                            </TableCell>


                        </TableRow>



                        </TableBody>


                    </Table>





                </Paper>



            </DialogContent>







            <DialogActions>


                <Button

                variant="contained"

                startIcon={
                    <PrintIcon/>
                }

                onClick={printVoucher}

                >

                    Print


                </Button>




                <Button

                variant="outlined"

                onClick={onClose}

                >

                    Close


                </Button>



            </DialogActions>





        </Dialog>


    );

};


export default JournalEntryView;