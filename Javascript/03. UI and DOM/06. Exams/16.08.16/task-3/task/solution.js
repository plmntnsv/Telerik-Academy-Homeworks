function solve() {
	return function () {
		var template = [
			'<h1>{{title}}</h1>',
				'<ul>',
				'{{#posts}}',
				'{{#unless deleted}}',
					'<li>',
						'<div class="post">',
						'{{#if author.length}}',
							'<p class="author"><a class="user" href="/user/{{author}}">{{author}}</a></p>',
						'{{else}}',
							'<p class="author"><a class="anonymous">Anonymous</a></p>',
						'{{/if}}',
							'<pre class="content">{{{text}}}</pre>',
						'</div>',
						'<ul>',
						'{{#if comments}}',
						'{{#comments}}',
						'{{#unless deleted}}',
							'<li>',
								'<div class="comment">',
								'{{#if author.length}}',
									'<p class="author"><a class="user" href="/user/{{author}}">{{author}}</a></p>',
								'{{else}}',
									'<p class="author"><a class="anonymous">Anonymous</a></p>',
								'{{/if}}',
									'<pre class="content">{{{text}}}</pre>',
								'</div>',
							'</li>',
							'{{/unless}}',
						'{{/comments}}',
						'{{/if}}',
						'</ul>',
					'</li>',
					'{{/unless}}',
				'{{/posts}}',
				'</ul>'
		].join('\n');

		return template;
	};
}

// submit the above

if (typeof module !== 'undefined') {
	module.exports = solve;
}