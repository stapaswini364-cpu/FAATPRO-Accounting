import { useEffect, useState } from "react";

import {
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography
} from "@mui/material";


import accountHeadApi from "../../api/accountHeadApi";



export default function AccountHeadList()
{

    const [heads,setHeads] = useState([]);



    useEffect(()=>{

        loadAccountHeads();

    },[]);




    const loadAccountHeads = async()=>{

        try
        {

            const data =
                await accountHeadApi.getAll();


            console.log(
                "ACCOUNT HEAD DATA:",
                data
            );


            setHeads(
                Array.isArray(data)
                ?
                data
                :
                data.data ?? []
            );


        }
        catch(error)
        {

            console.error(
                "Account Head Load Error",
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
                Account Head Master
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

                        </TableRow>

                    </TableHead>



                    <TableBody>


                        {
                            heads.map((head)=>(


                                <TableRow
                                    key={head.id}
                                >

                                    <TableCell>
                                        {head.code}
                                    </TableCell>


                                    <TableCell>
                                        {head.name}
                                    </TableCell>


                                    <TableCell>
                                        {head.nature}
                                    </TableCell>


                                    <TableCell>

                                        {
                                            head.isActive
                                            ?
                                            "Yes"
                                            :
                                            "No"
                                        }

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