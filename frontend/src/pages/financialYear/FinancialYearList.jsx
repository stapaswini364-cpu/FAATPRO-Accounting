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

import financialYearApi from "../../api/financialYearApi";


export default function FinancialYearList()
{

    const [years,setYears] = useState([]);



    useEffect(()=>{

        loadYears();

    },[]);



    const loadYears = async()=>{

        try{

            const data =
                await financialYearApi.getAll();


            console.log(
                "FINANCIAL YEAR DATA:",
                data
            );


            setYears(
                Array.isArray(data)
                ? data
                : data.data ?? []
            );


        }
        catch(error)
        {

            console.error(
                "Financial Year Load Error",
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
                Financial Year Master
            </Typography>


            <TableContainer>

                <Table>

                    <TableHead>

                        <TableRow>

                            <TableCell>
                                Year Name
                            </TableCell>

                            <TableCell>
                                Start Date
                            </TableCell>

                            <TableCell>
                                End Date
                            </TableCell>

                            <TableCell>
                                Current
                            </TableCell>

                        </TableRow>

                    </TableHead>


                    <TableBody>

                        {
                            years.map((year)=>(

                                <TableRow
                                    key={year.id}
                                >

                                    <TableCell>
                                        {year.yearName}
                                    </TableCell>


                                    <TableCell>
                                        {year.startDate}
                                    </TableCell>


                                    <TableCell>
                                        {year.endDate}
                                    </TableCell>


                                    <TableCell>
                                        {
                                            year.isCurrent
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