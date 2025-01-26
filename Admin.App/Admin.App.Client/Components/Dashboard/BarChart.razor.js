export function testenobre(report) {
    const chartContainer = document.getElementById("barchart");

    // Remove o gráfico existente (se houver) para evitar sobreposição
    chartContainer.innerHTML = "";

    // Configura as dimensões do SVG
    const width = report.width || 600;
    const height = report.height || 350;
    const barColour = report.barColour || "#000";

    // Cria o SVG para o gráfico
    const svg = d3
        .select(chartContainer)
        .append("svg")
        .attr("width", width)
        .attr("height", height);

    const data = report.chartData;

    // Configura as escalas
    const xScale = d3
        .scaleBand()
        .domain(data.map(d => d.dayOfWeek))
        .range([0, width])
        .padding(0.2);

    const yScale = d3
        .scaleLinear()
        .domain([0, d3.max(data, d => d.noOfClaims)])
        .range([height, 0]);

    // Adiciona os eixos
    svg.append("g")
        .attr("transform", `translate(0, ${height})`)
        .call(d3.axisBottom(xScale));

    svg.append("g")
        .call(d3.axisLeft(yScale));

    // Adiciona as barras
    svg.selectAll(".bar")
        .data(data)
        .enter()
        .append("rect")
        .attr("class", "bar")
        .attr("x", d => xScale(d.dayOfWeek))
        .attr("y", d => yScale(d.noOfClaims))
        .attr("width", xScale.bandwidth())
        .attr("height", d => height - yScale(d.noOfClaims))
        .attr("fill", barColour);
}
