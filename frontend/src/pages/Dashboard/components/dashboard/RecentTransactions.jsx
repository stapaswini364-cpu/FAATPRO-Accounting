import {
    Paper,
    Typography,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow
} from "@mui/material";


const RecentTransactions = () => {


    return (

        <Paper
            sx={{
                p:3,
                borderRadius:3
            }}
            elevation={3}
        >


            <Typography
                variant="h6"
                mb={2}
                fontWeight={600}
            >
                Recent Transactions
            </Typography>



            <Table>


                <TableHead>

                    <TableRow>

                        <TableCell>
                            Voucher No
                        </TableCell>


                        <TableCell>
                            Date
                        </TableCell>


                        <TableCell>
                            Type
                        </TableCell>


                        <TableCell>
                            Amount
                        </TableCell>


                    </TableRow>


                </TableHead>



                <TableBody>


                    <TableRow>

                        <TableCell>
                            -
                        </TableCell>


                        <TableCell>
                            -
                        </TableCell>


                        <TableCell>
                            No Data
                        </TableCell>


                        <TableCell>
                            ₹ 0
                        </TableCell>


                    </TableRow>


                </TableBody>


            </Table>


        </Paper>

    );

};


export default RecentTransactions;