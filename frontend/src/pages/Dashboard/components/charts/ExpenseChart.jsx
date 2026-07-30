import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from "recharts";

const expenseData = [
  {
    month: "Jan",
    expense: 5000,
  },
  {
    month: "Feb",
    expense: 8000,
  },
  {
    month: "Mar",
    expense: 12000,
  },
  {
    month: "Apr",
    expense: 9000,
  },
  {
    month: "May",
    expense: 15000,
  },
  {
    month: "Jun",
    expense: 18000,
  },
];

const ExpenseChart = () => {
  return (
    <ResponsiveContainer width="100%" height={250}>
      <BarChart data={expenseData}>
        <CartesianGrid />

        <XAxis dataKey="month" />

        <YAxis />

        <Tooltip />

        <Bar dataKey="expense" barSize={35} />
      </BarChart>
    </ResponsiveContainer>
  );
};

export default ExpenseChart;
