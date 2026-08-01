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

import accountGroupApi from "../../api/accountGroupApi";


export default function AccountGroupList({ refresh, onEdit }) {


    const [groups,setGroups] = useState([]);



    const loadGroups = async()=>{

        try
        {

            const data =
                await accountGroupApi.getAll();


            console.log(
                "Account Group API DATA:",
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
                "Account Group Load Error",
                error
            );

        }

    };



    useEffect(()=>{

        loadGroups();

    },[refresh]);




    const deleteGroup = async(id)=>{


        if(
            !window.confirm(
                "Delete Account Group?"
            )
        )
        return;



        try
        {

            await accountGroupApi.delete(id);

            loadGroups();

        }
        catch(error)
        {

            console.error(
                "Delete Account Group Error",
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

                Account Group Master

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

                                                deleteGroup(item.id)

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