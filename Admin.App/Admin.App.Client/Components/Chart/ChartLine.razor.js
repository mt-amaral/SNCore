export function testenobre(report) {
    const width = 1200;
    const height = 300;
    const marginTop = 18;
    const marginRight = 20;
    const marginBottom = 18;
    const marginLeft = 30;

    // Definir o intervalo de tempo (das 6h até agora)
    const agora = new Date();
    const inicio = new Date();
    inicio.setHours(6, 0, 0, 0);

    // Criar 18 pontos entre 6h e agora
    const numPontos = 23;
    const intervalo = (agora - inicio) / numPontos;

    const dados1 = Array.from({ length: numPontos }, (_, i) => ({
        tempo: new Date(inicio.getTime() + i * intervalo),
        valor: Math.random() * 100
    }));

    const dados2 = Array.from({ length: numPontos }, (_, i) => ({
        tempo: new Date(inicio.getTime() + i * intervalo),
        valor: Math.random() * 100
    }));

    // Criar escalas X e Y
    const x = d3.scaleTime().domain([inicio, agora]).range([marginLeft, width - marginRight]);
    const y = d3.scaleLinear().domain([0, 100]).range([height - marginBottom, marginTop]);

    // Criar o SVG
    const chartContainer = document.getElementById("barchart");
    const svg = d3.select(chartContainer)
        .append("svg")
        .attr("width", width)
        .attr("height", height);

    // Adicionar grades de fundo
    // Grade para eixo Y
    svg.append("g")
        .attr("class", "grid-y")
        .attr("transform", `translate(${marginLeft},0)`)
        .call(d3.axisLeft(y)
            .ticks(10)
            .tickSize(-(width - marginLeft - marginRight))
            .tickFormat(""))
        .selectAll(".tick line")
        .attr("stroke", "rgba(0, 0, 0, 0.3)")
        .attr("stroke-width", 0.5);

    // Grade para eixo X
    svg.append("g")
        .attr("class", "grid-x")
        .attr("transform", `translate(0,${height - marginBottom})`)
        .call(d3.axisBottom(x)
            .ticks(numPontos)
            .tickSize(-(height - marginTop - marginBottom))
            .tickFormat(""))
        .selectAll(".tick line")
        .attr("stroke", "rgba(0, 0, 0, 0.3)")
        .attr("stroke-width", 0.5);

    // Criar áreas preenchidas
    const area = d3.area()
        .x(d => x(d.tempo))
        .y0(height - marginBottom) // Base da área (eixo X)
        .y1(d => y(d.valor)) // Altura do valor no gráfico
        .curve(d3.curveMonotoneX);
    
    // Criar linha suavizada
    const linha = d3.line()
        .x(d => x(d.tempo))
        .y(d => y(d.valor))
        .curve(d3.curveMonotoneX);

    // Adicionar linha azul
    svg.append("path")
        .datum(dados1)
        .attr("fill", "none")
        .attr("stroke", "#1976d2")
        .attr("stroke-width", 2)
        .attr("stroke-linecap", "round") // Afinando as pontas
        .attr("d", linha);

    // Adicionar linha preta
    svg.append("path")
        .datum(dados2)
        .attr("fill", "none")
        .attr("stroke", "black")
        .attr("stroke-width", 2)
        .attr("stroke-linecap", "round") // Afinando as pontas
        .attr("d", linha);

    // Adicionar bolinhas nos nós para destacar os pontos
    svg.selectAll(".pontoAzul")
        .data(dados1)
        .enter()
        .append("circle")
        .attr("cx", d => x(d.tempo))
        .attr("cy", d => y(d.valor))
        .attr("r", 4) // Tamanho da bolinha
        .attr("fill", "#1976d2")
        .attr("stroke", "white") // Pequeno contorno para destacar
        .attr("stroke-width", 1);

    svg.selectAll(".pontoPreto")
        .data(dados2)
        .enter()
        .append("circle")
        .attr("cx", d => x(d.tempo))
        .attr("cy", d => y(d.valor))
        .attr("r", 4)
        .attr("fill", "black")
        .attr("stroke", "white")
        .attr("stroke-width", 1);

    // Adicionar eixo X visível
    svg.append("g")
        .attr("transform", `translate(0,${height - marginBottom})`)
        .call(d3.axisBottom(x).ticks(numPontos).tickFormat(d3.timeFormat("%H:%M")))
        .attr("color", "#333"); // Cor mais visível para os eixos

    // Adicionar eixo Y visível
    svg.append("g")
        .attr("transform", `translate(${marginLeft},0)`)
        .call(d3.axisLeft(y))
        .attr("color", "#333"); // Cor mais visível para os eixos
    
    
    
}

