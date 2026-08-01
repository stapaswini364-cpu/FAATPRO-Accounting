import {useState} from "react";

import LedgerForm from "./components/LedgerForm";
import LedgerList from "./LedgerList";


export default function Ledger(){

    const [refresh,setRefresh] = useState(false);

    const [editData,setEditData] = useState(null);


    const handleSuccess = ()=>{

        setEditData(null);

        setRefresh(!refresh);

    };


    return (

        <>

            <LedgerForm

                editData={editData}

                onSuccess={handleSuccess}

            />


            <LedgerList

                refresh={refresh}

                onEdit={(data)=>
                    setEditData(data)
                }

            />


        </>

    );

}