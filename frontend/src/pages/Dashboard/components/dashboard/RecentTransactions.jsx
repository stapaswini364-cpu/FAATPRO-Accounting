import { useEffect, useState } from "react";

import {
    Paper,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow
} from "@mui/material";


import {
    getRecentTransactions
} from "../../../../api/dashboardApi";



const RecentTransactions = () => {


    const [
        transactions,
        setTransactions
    ] = useState([]);



    useEffect(()=>{

        loadTransactions();

    },[]);





    const loadTransactions = async()=>{


        try{


            const response =
                await getRecentTransactions();



            console.log(
                "Recent Transaction API:",
                response
            );



            const data =
                response?.data
                ??
                response;



            setTransactions(

                Array.isArray(data)
                ?
                data
                :
                []

            );


        }
        catch(error){


            console.error(
                "Recent Transaction Error",
                error
            );


            setTransactions([]);


        }


    };







    return (

        <Paper

            sx={{
                p:3,
                borderRadius:3
            }}

            elevation={3}

        >


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


                {

                    transactions.length > 0

                    ?

                    transactions.map(

                        (item,index)=>(


                            <TableRow

                                key={index}

                            >



                                <TableCell>

                                    {
                                        item.voucherNo
                                        ??
                                        item.voucherNumber
                                        ??
                                        "-"
                                    }

                                </TableCell>





                                <TableCell>


                                    {

                                        item.date

                                        ?

                                        new Date(
                                            item.date
                                        )
                                        .toLocaleDateString()

                                        :

                                        "-"

                                    }


                                </TableCell>





                                <TableCell>

                                    {

                                        item.type
                                        ??
                                        item.entryType
                                        ??
                                        "Journal"

                                    }

                                </TableCell>





                                <TableCell>


                                    ₹ {

                                        item.amount
                                        ??
                                        item.totalAmount
                                        ??
                                        0

                                    }


                                </TableCell>




                            </TableRow>


                        )

                    )


                    :


                    <TableRow>


                        <TableCell

                            colSpan={4}

                            align="center"

                        >

                            No Transactions Found

                        </TableCell>


                    </TableRow>


                }


                </TableBody>


            </Table>



        </Paper>

    );


};



export default RecentTransactions;