import { useEffect, useState } from "react";

import {
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    ResponsiveContainer,
    ReferenceLine
} from "recharts";


import { getCashFlowChart } from "../../../../api/dashboardApi";



const CashFlowChart = () => {


    const [data,setData] = useState([]);

    const [loading,setLoading] = useState(true);





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



            if(Array.isArray(response))
            {

                const chartData =

                    response

                    .map(item=>({

                        month:
                            item.month,

                        amount:
                            Number(
                                item.amount ?? 0
                            )

                    }))

                    .sort(
                        (a,b)=>
                        a.month.localeCompare(
                            b.month
                        )
                    );



                setData(chartData);

            }


        }
        catch(error)
        {

            console.error(
                "Cash Flow Chart Error",
                error
            );

        }
        finally
        {

            setLoading(false);

        }

    };








    if(loading)
    {

        return (

            <div>
                Loading Cash Flow...
            </div>

        );

    }







    if(data.length === 0)
    {

        return (

            <div>
                No Cash Flow Data Available
            </div>

        );

    }








    return(

        <ResponsiveContainer

            width="100%"

            height={300}

        >


            <LineChart

                data={data}

            >



                <CartesianGrid

                    strokeDasharray="3 3"

                />





                <XAxis

                    dataKey="month"

                />





                <YAxis />






                <Tooltip


                    formatter={

                        (value)=>

                        `₹ ${
                            Number(value)
                            .toLocaleString(
                                "en-IN"
                            )
                        }`

                    }

                />





                {/* Zero Line */}

                <ReferenceLine

                    y={0}

                    stroke="black"

                />








                <Line


                    type="monotone"


                    dataKey="amount"


                    name="Net Cash Flow"


                    strokeWidth={3}


                    dot={true}


                    activeDot={{
                        r:6
                    }}


                />



            </LineChart>



        </ResponsiveContainer>


    );

};



export default CashFlowChart;