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
    Stack
} from "@mui/material";

import accountSubGroupApi from "../../api/accountSubGroupApi";


export default function AccountSubGroupList({
    refresh,
    onEdit
}) {


    const [groups,setGroups] = useState([]);



    const loadData = async()=>{

        try
        {

            const data =
                await accountSubGroupApi.getAll();


            console.log(
                "Account Sub Group DATA:",
                data
            );


            setGroups(

                Array.isArray(data)

                ?

                data

                :

                []

            );


        }
        catch(error)
        {

            console.error(
                "Account Sub Group Load Error",
                error
            );

        }

    };




    useEffect(()=>{

        loadData();

    },[refresh]);





    const deleteItem = async(id)=>{


        if(
            !window.confirm(
                "Delete Account Sub Group?"
            )
        )
        return;



        try
        {

            await accountSubGroupApi.delete(id);

            loadData();

        }
        catch(error)
        {

            console.error(
                "Delete Error",
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

                Account Sub Group Master

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
                                Nature
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

                        groups.map((item)=>(


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

                                        item.nature === 0

                                        ?

                                        "Debit"

                                        :

                                        "Credit"

                                    }


                                </TableCell>




                                <TableCell>


                                    {

                                        item.isActive

                                        ?

                                        "Yes"

                                        :

                                        "No"

                                    }


                                </TableCell>





                                <TableCell>


                                    <Stack

                                        direction="row"

                                        spacing={1}

                                    >


                                        <Button

                                            size="small"

                                            variant="outlined"

                                            onClick={()=>onEdit(item)}

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