export const formatDate = (utcTimeString) => {
    const utcDate = new Date(utcTimeString);
    const istDate = new Date(
      utcDate.toLocaleString("en-US", { timeZone: "Asia/Kolkata" })
    );
  
    const formattedDate = `${istDate.getDate().toString().padStart(2, "0")}/${(
      istDate.getMonth() + 1
    )
      .toString()
      .padStart(2, "0")}/${istDate.getFullYear()} ${istDate
      .getHours()
      .toString()
      .padStart(2, "0")}:${istDate.getMinutes().toString().padStart(2, "0")}`;
  
    return formattedDate;
  };
  
//   export const filterDataByIds = (data, ids) => {
//     return data.filter((item) => ids.includes(item.firm_id));
//   };