import { useState } from "react";

import Sidebar from "../components/sidebar/Sidebar";
import Header from "../components/header/Header";
import Footer from "../components/footer/Footer";

import Breadcrumb from "../components/breadcrumb/Breadcrumb";
import NotificationArea from "../components/notification/NotificationArea";


const MainLayout = ({ children }) => {

  const [open, setOpen] = useState(false);


  return (

    <div className="flex min-h-screen">


      {/* Sidebar */}

      <Sidebar
        open={open}
        setOpen={setOpen}
      />



      <div className="flex flex-col flex-1">



        {/* Header */}

        <Header
          setOpen={setOpen}
        />



        {/* Notification Area */}

        <NotificationArea />



        {/* Page Content */}

        <main className="flex-1 p-6 bg-gray-100">


          {/* Breadcrumb */}

          <Breadcrumb />



          {/* Dynamic Page Content */}

          {children}


        </main>



        {/* Footer */}

        <Footer />


      </div>


    </div>

  );

};


export default MainLayout;