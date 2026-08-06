import { useEffect, useState } from "react";

import {
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    ResponsiveContainer
} from "recharts";


import { getCashFlowChart } from "../../../../api/dashboardApi";



const CashFlowChart = () => {


    const [data,setData] = useState([]);



    useEffect(()=>{

        loadCashFlow();

    },[]);




    const loadCashFlow = async()=>{

        try{

            const response =
                await getCashFlowChart();


            console.log(
                "Cash Flow Chart API:",
                response
            );


            setData(

                Array.isArray(response)

                ? response.map(item=>({

                    month:item.month,

                    amount:item.amount

                }))

                : []

            );


        }
        catch(error){

            console.error(
                "Cash Flow Chart Error",
                error
            );

        }

    };




    return (

        <ResponsiveContainer
            width="100%"
            height={300}
        >

            <LineChart
                data={data}
            >

                <CartesianGrid />

                <XAxis
                    dataKey="month"
                />

                <YAxis />

                <Tooltip
                    formatter={
                        (value)=>
                            `₹ ${value.toLocaleString()}`
                    }
                />


                <Line

                    type="monotone"

                    dataKey="amount"

                    strokeWidth={3}

                />


            </LineChart>


        </ResponsiveContainer>

    );

};


export default CashFlowChart;