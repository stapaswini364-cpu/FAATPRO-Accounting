import { useEffect, useState } from "react";

import {
    Box,
    Button,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography
} from "@mui/material";


import companyApi from "../../api/companyApi";


export default function CompanyList()
{

    const [companies,setCompanies] = useState([]);



    const loadCompanies = async()=>{

        const data = await companyApi.getAll();

        setCompanies(data);

    };



    useEffect(()=>{

        loadCompanies();

    },[]);





    return (

        <Box>

            <Typography variant="h5" mb={3}>
                Company Master
            </Typography>



            <Button
                variant="contained"
                sx={{mb:2}}
            >
                Add Company
            </Button>




            <TableContainer component={Paper}>

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
                                Active
                            </TableCell>

                        </TableRow>

                    </TableHead>



                    <TableBody>

                        {
                            companies.map((item)=>(

                                <TableRow key={item.id}>

                                    <TableCell>
                                        {item.code}
                                    </TableCell>


                                    <TableCell>
                                        {item.name}
                                    </TableCell>


                                    <TableCell>
                                        {
                                            item.isActive
                                            ? "Yes"
                                            : "No"
                                        }
                                    </TableCell>


                                </TableRow>

                            ))
                        }


                    </TableBody>


                </Table>

            </TableContainer>


        </Box>

    );

}