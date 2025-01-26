export function testenobre(reportData) {
    console.log("Atualizando gráfico", reportData);

    // Configurações iniciais do gráfico
    const svgWidth = reportData.width;
    const svgHeight = reportData.height;
    const margin = { top: 0, right: 20, bottom: 0, left: 40 };
    const width = svgWidth - margin.left - margin.right;
    const height = svgHeight - margin.top - margin.bottom;

    // Seleciona o contêiner do gráfico e limpa o conteúdo anterior, se houver
    const chartContainer = d3.select(".grid-stack-item");

    // Criação ou atualização do elemento SVG
    const svg = chartContainer
        .append("svg") // Adiciona o elemento SVG
        .attr("width", "100%") // Largura 100%
        .attr("height", "100%") // Altura 100%
        .attr("preserveAspectRatio", "xMaxYMax meet")
        .attr("viewBox", "0 0 960 400")
        .append("g") // Adiciona um grupo
        .attr("transform", `translate(${margin.left}, ${margin.top})`); // Aplica margens

    // Configuração das escalas
    const xScale = d3.scaleBand()
        .domain(reportData.chartData.map(d => d.dayOfWeek))
        .range([0, width])
        .padding(0.1);

    const yScale = d3.scaleLinear()
        .domain([0, d3.max(reportData.chartData, d => d.noOfClaims)])
        .range([height, 0]);

    // Vincula os dados às barras do gráfico
    const bars = svg.selectAll("rect")
        .data(reportData.chartData);

    // Atualiza as barras existentes ou adiciona novas
    bars.enter()
        .append("rect") // Cria as barras
        .merge(bars) // Mescla com barras existentes
        .attr("x", d => xScale(d.dayOfWeek))
        .attr("y", d => yScale(d.noOfClaims))
        .attr("width", xScale.bandwidth())
        .attr("height", d => height - yScale(d.noOfClaims))
        .attr("fill", reportData.barColour);

    // Remove barras que não são mais necessárias
    bars.exit().remove();

    // Criação ou atualização do eixo X
    svg.append("g")
        .attr("transform", `translate(0, ${height})`)
        .call(d3.axisBottom(xScale));

    // Criação ou atualização do eixo Y
    svg.append("g")
        .call(d3.axisLeft(yScale));

    // Rótulo do eixo X
    svg.append("text")
        .attr("class", "x label")
        .attr("text-anchor", "middle")
        .attr("x", width / 2)
        .attr("y", height + margin.bottom - 10)
        .text("Days of the Week");

    // Rótulo do eixo Y
    svg.append("text")
        .attr("class", "y label")
        .attr("text-anchor", "middle")
        .attr("x", -(height / 2))
        .attr("y", -margin.left + 15)
        .attr("dy", "1em")
        .attr("transform", "rotate(-90)")
        .text("No. of Claims");
}
