function solve() {
    return function() {
        var template = `
			<ul class="nav">
			{{#if logo}}
				<li class="nav-item logo">
					<a href="{{logo.url}}">
						<img src="{{logo.image}}" />
					</a>
				</li>
				{{/if}}
				{{#items}}
				<li class="nav-item">
					<a href="{{this.url}}">{{this.title}}</a>
					{{#if this.items}}
					<ul class="subnav">
						{{#this.items}}
						<li class="nav-item">
							<a href="{{this.url}}">{{this.title}}</a>
						</li>
						{{/this.items}}
					</ul>
				{{/if}}
				</li>
				{{/items}}
			</ul>
`;
        return template;
    };
}

module.exports = solve;