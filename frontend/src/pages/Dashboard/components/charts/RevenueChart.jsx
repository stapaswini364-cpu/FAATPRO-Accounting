import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";

const revenueData = [
  {
    month: "Jan",
    revenue: 12000,
  },
  {
    month: "Feb",
    revenue: 18000,
  },
  {
    month: "Mar",
    revenue: 15000,
  },
  {
    month: "Apr",
    revenue: 25000,
  },
  {
    month: "May",
    revenue: 30000,
  },
  {
    month: "Jun",
    revenue: 42000,
  },
];

const RevenueChart = () => {
  return (
    <ResponsiveContainer width="100%" height={300}>
      <LineChart data={revenueData}>
        <CartesianGrid />

        <XAxis dataKey="month" />

        <YAxis />

        <Tooltip />

        <Line type="monotone" dataKey="revenue" strokeWidth={3} />
      </LineChart>
    </ResponsiveContainer>
  );
};

export default RevenueChart;
