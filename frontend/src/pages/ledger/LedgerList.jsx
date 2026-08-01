import { useEffect, useState } from "react";

import {
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
    Button,
    Stack,
    Chip
} from "@mui/material";


import ledgerApi from "../../api/ledgerApi";

import accountHeadApi from "../../api/accountHeadApi";

import accountGroupApi from "../../api/accountGroupApi";

import accountSubGroupApi from "../../api/accountSubGroupApi";





export default function LedgerList({

    refresh,

    onEdit

}) {



    const [ledgers,setLedgers] = useState([]);

    const [accountHeads,setAccountHeads] = useState([]);

    const [accountGroups,setAccountGroups] = useState([]);

    const [accountSubGroups,setAccountSubGroups] = useState([]);








    const loadData = async()=>{


        try{


            const ledgerData =
                await ledgerApi.getAll();


            const headData =
                await accountHeadApi.getAll();


            const groupData =
                await accountGroupApi.getAll();


            const subGroupData =
                await accountSubGroupApi.getAll();





            setLedgers(

                Array.isArray(ledgerData)

                ?

                ledgerData

                :

                []

            );




            setAccountHeads(

                Array.isArray(headData)

                ?

                headData

                :

                []

            );




            setAccountGroups(

                Array.isArray(groupData)

                ?

                groupData

                :

                []

            );




            setAccountSubGroups(

                Array.isArray(subGroupData)

                ?

                subGroupData

                :

                []

            );



        }

        catch(error){


            console.error(
                "Ledger Load Error",
                error
            );


        }


    };








    useEffect(()=>{


        loadData();


    },[refresh]);









    const getHeadName=(id)=>{


        const item =
            accountHeads.find(
                x=>x.id===id
            );


        return item
            ?
            item.name
            :
            "-";


    };








    const getGroupName=(id)=>{


        const item =
            accountGroups.find(
                x=>x.id===id
            );


        return item
            ?
            item.name
            :
            "-";


    };








    const getSubGroupName=(id)=>{


        const item =
            accountSubGroups.find(
                x=>x.id===id
            );


        return item
            ?
            item.name
            :
            "-";


    };









    const deleteItem = async(id)=>{


        if(
            !window.confirm(
                "Delete Ledger?"
            )
        )

        return;




        try{


            await ledgerApi.delete(id);


            loadData();


        }

        catch(error){


            console.error(
                "Ledger Delete Error",
                error
            );


        }


    };









    return (


        <Paper sx={{p:3}}>


            <Typography

                variant="h5"

                mb={2}

            >

                Ledger Master

            </Typography>







            <TableContainer>


                <Table>



                    <TableHead>


                        <TableRow>


                            <TableCell>
                                Code
                            </TableCell>


                            <TableCell>
                                Name
                            </TableCell>


                            <TableCell>
                                Account Head
                            </TableCell>


                            <TableCell>
                                Account Group
                            </TableCell>


                            <TableCell>
                                Account Sub Group
                            </TableCell>


                            <TableCell>
                                Opening Balance
                            </TableCell>


                            <TableCell>
                                Type
                            </TableCell>


                            <TableCell>
                                Active
                            </TableCell>


                            <TableCell>
                                Action
                            </TableCell>


                        </TableRow>


                    </TableHead>








                    <TableBody>



                    {
                        
                    ledgers.length === 0

                    ?

                    (

                    <TableRow>


                        <TableCell

                            colSpan={9}

                            align="center"

                        >

                            No Ledger Found

                        </TableCell>


                    </TableRow>

                    )


                    :


                    ledgers.map((item)=>(


                        <TableRow

                            key={item.id}

                        >



                            <TableCell>

                                {item.code}

                            </TableCell>





                            <TableCell>

                                {item.name}

                            </TableCell>






                            <TableCell>

                                {
                                    getHeadName(
                                        item.accountHeadId
                                    )
                                }

                            </TableCell>






                            <TableCell>

                                {
                                    getGroupName(
                                        item.accountGroupId
                                    )
                                }

                            </TableCell>






                            <TableCell>

                                {
                                    getSubGroupName(
                                        item.accountSubGroupId
                                    )
                                }

                            </TableCell>






                            <TableCell>

                                {
                                    Number(
                                        item.openingBalance
                                    )
                                    .toLocaleString()
                                }

                            </TableCell>






                            <TableCell>

                            {

                                item.balanceType === 0

                                ?

                                "Debit"

                                :

                                "Credit"

                            }

                            </TableCell>








                            <TableCell>


                                <Chip

                                    size="small"

                                    label={

                                        item.isActive

                                        ?

                                        "Active"

                                        :

                                        "Inactive"

                                    }

                                />


                            </TableCell>









                            <TableCell>


                                <Stack

                                    direction="row"

                                    spacing={1}

                                >



                                    <Button

                                        size="small"

                                        variant="outlined"

                                        onClick={()=>

                                            onEdit(item)

                                        }

                                    >

                                        Edit

                                    </Button>







                                    <Button

                                        size="small"

                                        color="error"

                                        variant="contained"

                                        onClick={()=>

                                            deleteItem(item.id)

                                        }

                                    >

                                        Delete

                                    </Button>




                                </Stack>


                            </TableCell>





                        </TableRow>


                    ))


                    }



                    </TableBody>



                </Table>


            </TableContainer>



        </Paper>


    );


}